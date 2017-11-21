using Library.Domain.Core;
using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Infrastructure.DataPersistence.Inventory.SQLServer;
using Library.Infrastructure.DataPersistence.Rental.SQLServer;
using Library.Infrastructure.EventStorage.SQLServer;
using Library.Infrastructure.InjectionFramework;
using Library.Infrastructure.Logger.SQLServer;
using Library.Infrastructure.Messaging.RabbitMQ;
using Library.Infrastructure.Messaging.SignalR;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Rental.Domain.DataAccessors;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Library.Service.Handler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Injection();

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

        private static void Injection()
        {
            InjectContainer.RegisterType<ILogDBConnectionStringProvider, AppsettingLogDBConnectionStringProvider>();
            InjectContainer.RegisterType<ILogger, Logger>();
            InjectContainer.RegisterType<IDomainRepository, DomainRepository>();
            InjectContainer.RegisterType<IEventStorage, SQLServerEventStorage>();
            InjectContainer.RegisterType<IRabbitMQUrlProvider, AppsettingRabbitMQUrlProvider>();
            InjectContainer.RegisterType<IEventPublisher, RabbitMQEventPublisher>();
            InjectContainer.RegisterType<IEventSubscriber, RabbitMQEventSubscriber>();

            InjectContainer.RegisterType<ICommandSubscriber, RabbitMQCommandSubscriber>();


            InjectContainer.RegisterType<IEventDBConnectionStringProvider, AppSettingEventDBConnectionStringProvider>();

            InjectContainer.RegisterType<IInventoryReadDBConnectionStringProvider, AppsettingInventoryReadDBConnectionStringProvider>();
            InjectContainer.RegisterType<IInventoryWriteDBConnectionStringProvider, AppsettingInventoryWriteDBConnectionStringProvider>();
            InjectContainer.RegisterType<IInventoryReportDataAccessor, InventoryReportDataAccessor>();

            InjectContainer.RegisterType<IRentalReadDBConnectionStringProvider, AppsettingRentalReadDBConnectionStringProvider>();
            InjectContainer.RegisterType<IRentalWriteDBConnectionStringProvider, AppsettingRentalWriteDBConnectionStringProvider>();
            InjectContainer.RegisterType<IRentalReportDataAccessor, RentalReportDataAccessor>();
            InjectContainer.RegisterType<ISignalRConnectionProvider, AppsettingSignalRConnectionProvider>();
            InjectContainer.RegisterType<ICommandTracker, SignalRCommandTracker>();


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