using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.InjectionFramework;
using Library.Infrastructure.Messaging.RabbitMQ;
using System;
using System.Linq;
using System.Reflection;

namespace Library.Service.Handler
{
    public class HandlerRegister
    {
        public HandlerRegister()
        {
        }

        public void RegisterAndStart(string libraryName)
        {
            var connectionString = InjectContainer.GetInstance<IEventDBConnectionStringProvider>().ConnectionString;

            Console.WriteLine($"Handler starting...");
            Console.WriteLine($"Event DB Connection String: {connectionString}");

            RegisterAndStartCommandHandlers(libraryName);
            RegisterAndStartEventHandlers(libraryName);

            Console.WriteLine($"Handler started.");
        }

        public void RegisterAndStartCommandHandlers(string libraryName)
        {
            var assembly = Assembly.Load(libraryName);

            var allCommands = assembly.GetExportedTypes().Where(p => p.GetInterface("ICommand") != null);
            foreach (var command in allCommands)
            {
                var register = new RabbitMQCommandSubscriber("amqp://localhost:5672");
                var registerMethod = register.GetType().GetMethod("Subscribe");

                var cmd = Activator.CreateInstance(command);
                Console.WriteLine($"Find command {command.FullName}.");
                registerMethod.MakeGenericMethod(command).Invoke(register, new object[1] { cmd });
            }
        }

        public void RegisterAndStartEventHandlers(string libraryName)
        {
            var assembly = Assembly.Load(libraryName);

            var allEvents = assembly.GetExportedTypes().Where(p => p.GetInterface("IDomainEvent") != null);
            foreach (var @event in allEvents)
            {
                var register = new RabbitMQEventSubscriber("amqp://localhost:5672", InjectContainer.GetInstance<ICommandTracker>());

                if (register != null)
                {
                    var registerMethod = register.GetType().GetMethod("Subscribe");

                    var cmd = Activator.CreateInstance(@event);
                    Console.WriteLine($"Find event {@event.FullName}.");
                    registerMethod.MakeGenericMethod(@event).Invoke(register, new object[1] { cmd });
                }
            }
        }
    }
}