using System;
using System.Reflection;
using System.Linq;
using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Infrastructure.Messaging.RabbitMQ;

namespace BookingLibrary.Service.Repository.Handler
{
    public class RepositoryHandlerRegister
    {
        public RepositoryHandlerRegister()
        {

        }

        public void RegisterAndStart()
        {
            var register = new RabbitMQCommandSubscriber("amqp://localhost:5672");
            var registerMethod = register.GetType().GetMethod("Subscribe");
            var assembly = Assembly.Load("BookingLibrary.Service.Repository.Application");

            var allCommands = assembly.GetExportedTypes().Where(p => p.GetInterface("ICommand") != null);
            foreach (var command in allCommands)
            {
                var cmd = Activator.CreateInstance(command);
                Console.WriteLine($"Find command {command.FullName}.");
                registerMethod.MakeGenericMethod(command).Invoke(register, new object[1] { cmd });
            }
        }
    }
}