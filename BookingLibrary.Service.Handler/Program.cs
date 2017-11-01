using System;
using System.Reflection;
using System.Linq;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Infrastructure.InjectionFramework;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Infrastructure.EventStorage.SQLServer;
using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.Messaging;
using BookingLibrary.Infrastructure.Messaging.RabbitMQ;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Infrastructure.DataPersistence.Repository.SQLServer;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

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
            InjectContainer.RegisterType<IRepositoryReadDBConnectionStringProvider, AppsettingRepositoryReadDBConnectionStringProvider>();
            InjectContainer.RegisterType<IRepositoryWriteDBConnectionStringProvider, AppsettingRepositoryWriteDBConnectionStringProvider>();
            InjectContainer.RegisterType<IRepositoryReportDataAccessor, RepositoryReportDataAccessor>();


            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var s_handlers = configuration.GetSection("handlers").GetChildren();
            var handlers = new List<HandlerConfigurationDTO>();

            foreach (IConfigurationSection s_handler in s_handlers)
            {
                handlers.Add(new HandlerConfigurationDTO{
                   Name = s_handler["name"],
                   LibraryName = s_handler["libraryName"]
                });
            }

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
