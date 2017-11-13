using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Domain.Core.Messaging;
using BookingLibrary.Infrastructure.DataPersistence.Inventory.SQLServer;
using BookingLibrary.Infrastructure.DataPersistence.Rental.SQLServer;
using BookingLibrary.Infrastructure.EventStorage.SQLServer;
using BookingLibrary.Infrastructure.InjectionFramework;
using BookingLibrary.Infrastructure.Messaging.RabbitMQ;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Rental.Domain.DataAccessors;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BookingLibrary.Service.Handler
{
    class Program
    {
        static void Main(string[] args)
        {

            InjectContainer.RegisterType<IDomainRepository, DomainRepository>();
            InjectContainer.RegisterType<IEventStorage, SQLServerEventStorage>();
            InjectContainer.RegisterInstance<IEventPublisher>(new RabbitMQEventPublisher("amqp://localhost:5672"));
            InjectContainer.RegisterType<IEventDBConnectionStringProvider, AppSettingEventDBConnectionStringProvider>();

            //这一部分需要重构到配置文件中
            InjectContainer.RegisterType<IInventoryReadDBConnectionStringProvider, AppsettingInventoryReadDBConnectionStringProvider>();
            InjectContainer.RegisterType<IInventoryWriteDBConnectionStringProvider, AppsettingInventoryWriteDBConnectionStringProvider>();
            InjectContainer.RegisterType<IInventoryReportDataAccessor, InventoryReportDataAccessor>();

            InjectContainer.RegisterType<IRentalReadDBConnectionStringProvider, AppsettingRentalReadDBConnectionStringProvider>();
            InjectContainer.RegisterType<IRentalWriteDBConnectionStringProvider, AppsettingRentalWriteDBConnectionStringProvider>();
            InjectContainer.RegisterType<IRentalReportDataAccessor, RentalReportDataAccessor>();


            var handlers = BuildHandlerConfigurations();

            HandlerRegister register = new HandlerRegister();
            foreach (var handler in handlers)
            {
                Console.WriteLine($"Starting handler '{handler.Name}'");
                RegisterCommandHandlers(handler.LibraryName);
                RegisterEventHandlers(handler.LibraryName);
                register.RegisterAndStart(handler.LibraryName);

                Console.WriteLine($"Started handler '{handler.Name}'");
            }
        }

        private static List<HandlerConfigurationDTO> BuildHandlerConfigurations()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var s_handlers = configuration.GetSection("handlers").GetChildren();
            var handlers = new List<HandlerConfigurationDTO>();

            foreach (IConfigurationSection s_handler in s_handlers)
            {
                handlers.Add(new HandlerConfigurationDTO
                {
                    Name = s_handler["name"],
                    LibraryName = s_handler["libraryName"]
                });
            }

            return handlers;
        }

        private static void RegisterCommandHandlers(string libraryName)
        {
            Func<Type, bool> isCommandHandler = i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>);

            var commandHandlers = Assembly.Load(libraryName).GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(isCommandHandler))
                .ToList();

            var registerSource = commandHandlers.Select(h =>
            {
                return new { FromType = h.GetInterfaces().First(isCommandHandler), ToType = h };
            }).ToList();

            foreach (var r in registerSource)
            {
                InjectContainer.RegisterType(r.FromType, r.ToType);
            }
        }

        private static void RegisterEventHandlers(string libraryName)
        {
            Func<Type, bool> isEventHandler = i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>);

            var commandHandlers = Assembly.Load(libraryName).GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(isEventHandler))
                .ToList();

            var registerSource = commandHandlers.Select(h =>
            {
                return new { FromType = h.GetInterfaces().First(isEventHandler), ToType = h };
            }).ToList();

            foreach (var r in registerSource)
            {
                InjectContainer.RegisterType(r.FromType, r.ToType);
            }
        }
    }
}
