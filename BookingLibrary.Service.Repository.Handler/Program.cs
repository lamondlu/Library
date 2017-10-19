using System;
using System.Reflection;
using System.Linq;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Infrastructure.InjectionFramework;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Infrastructure.EventStorage.SQLServer;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Handler
{
    class Program
    {
        static void Main(string[] args)
        {
            InjectContainer.RegisterType<IDomainRepository, DomainRepository>();
            InjectContainer.RegisterType<IEventStorage, SQLServerEventStorage>();
            RegisterHandlers();

            RepositoryHandlerRegister register = new RepositoryHandlerRegister();
            register.RegisterAndStart();
        }

        private static void RegisterHandlers()
        {
            Func<Type, bool> isCommandHandler = i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>);


            var commandHandlers = Assembly.Load("BookingLibrary.Service.Repository.Application").GetExportedTypes()
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
    }
}
