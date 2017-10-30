using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using BookLibrary.SignalR.Models;

namespace BookLibrary.SignalR.Hubs
{
    public class CommandHub : Hub
    {
        private static Dictionary<Guid, CommandResult> _results = null;

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
            result.EventResults = obj.EventNames.Select(p => new EventResult { EventName = p, IsFinished = false, IsError = false }).ToList();

            CommandHub._results.Add(obj.CommandUniqueId, result);
        }

        public void CommandStatusChange(CommandStatusChangeObject obj)
        {
            var matchedCommandItem = _results[obj.CommandUniqueId];

            if (matchedCommandItem != null)
            {
                if (obj.IsError)
                {
                    Clients.Client(matchedCommandItem.ConnectionId).failure();
                }
                else if (obj.IsFinished)
                {
                    var item = matchedCommandItem.EventResults.First(p => p.EventName == obj.EventName);

                    item.IsFinished = true;

                    if (matchedCommandItem.IsFinished)
                    {
                        Clients.Client(matchedCommandItem.ConnectionId).success();
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