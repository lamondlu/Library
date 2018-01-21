using Library.SignalR.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.SignalR.Hubs
{
	public class CommandHub : Hub
	{
		private static Dictionary<Guid, CommandResult> _results = null;
		private IHubContext _hub = GlobalHost.ConnectionManager.GetHubContext<CommandHub>();

		static CommandHub()
		{
			_results = new Dictionary<Guid, CommandResult>();
		}

		public CommandHub()
		{
		}

		public void JoinGroup(Guid commandUnqiueId)
		{
			this.Groups.Add(this.Context.ConnectionId, commandUnqiueId.ToString());
		}

		public void QuitGroup(Guid commandUnqiueId)
		{
			this.Groups.Remove(this.Context.ConnectionId, commandUnqiueId.ToString());
		}

		public void MonitorCommand(MonitoredCommand obj)
		{
			var result = new CommandResult();
			result.CommandUniqueId = obj.CommandUniqueId;
			result.EventResults = obj.EventNames.Select(p => new EventResult { EventName = p, IsFinished = false, IsError = false }).ToList();

			CommandHub._results.Add(obj.CommandUniqueId, result);
		}

		public void CommandStatusChangeDirectly(Guid commandUniqueId, bool isFinished, bool isError, string errorCode, string errorMessage)
		{
			if (isError)
			{
				_hub.Clients.All.failure(commandUniqueId, errorCode, errorMessage);
			}
			else if (isFinished)
			{
				_hub.Clients.All.success(commandUniqueId);
			}
		}

		public void CommandStatusChange(CommandStatusChangeObject obj)
		{
			var matchedCommandItem = _results[obj.CommandUniqueId];

			if (matchedCommandItem != null)
			{
				if (obj.IsError)
				{
					_hub.Clients.All.failure(obj.CommandUniqueId, obj.ErrorCode, obj.ErrorMessage);
				}
				else if (obj.IsFinished)
				{
					var item = matchedCommandItem.EventResults.First(p => p.EventName == obj.EventName);

					item.IsFinished = true;

					if (matchedCommandItem.IsFinished)
					{
						_hub.Clients.All.success(obj.CommandUniqueId);
					}
				}
			}
		}

		public void RemoveCommand(Guid commandUniqueId)
		{
			var matchedCommandItem = _results[commandUniqueId];

			if (matchedCommandItem != null)
			{
				_results.Remove(commandUniqueId);
			}
		}
	}
}