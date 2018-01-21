using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Library.Domain.Core
{
	public interface ILogger
	{
		void EventError<T>(T eventObject, string message) where T : DomainEvent;

		void CommandError<T>(T command, string message) where T : CommonCommand;

		void EventInfo<T>(T eventObject, string message) where T : DomainEvent;

		void CommandInfo<T>(T command, string message) where T : CommonCommand;

		void EventWarning<T>(T eventObject, string message) where T : DomainEvent;

		void CommandWarning<T>(T command, string message) where T : CommonCommand;

		List<CommandLogModel> GetCommandLogs();

		List<CommandLogModel> GetEventLogs(Guid commandUniqueId);
	}
}