using Library.Domain.Core;
using Library.Domain.Core.Commands;
using Library.Infrastructure.InjectionFramework;
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
			var mappings = GetConfiguration().GetSection("diMappings").GetChildren();

			foreach (IConfigurationSection mapping in mappings)
			{
				var source = Assembly.Load(mapping["sAssembly"]).GetType(mapping["interface"]);
				var target = Assembly.Load(mapping["tAssembly"]).GetType(mapping["implementation"]);

				InjectContainer.RegisterType(source, target);
			}
		}

		private static List<HandlerConfigurationDTO> BuildHandlerConfigurations()
		{
			var s_handlers = GetConfiguration().GetSection("handlers").GetChildren();
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

		private static IConfigurationRoot GetConfiguration()
		{
			var builder = new ConfigurationBuilder()
					   .SetBasePath(Directory.GetCurrentDirectory())
					   .AddJsonFile("appsettings.json");

			var configuration = builder.Build();

			return configuration;
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