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
        private static List<CommandResult> _results = null;

        static CommandHub()
        {
            _results = new List<CommandResult>();
        }

        public CommandHub()
        {

        }

        public void MonitorCommand(MonitorObject obj)
        {
            var result = new CommandResult();
            result.ConnectionId = this.Context.ConnectionId;
            result.EventResults = obj.EventNames.Select(p => new EventResult { EventName = p, IsFinished = false, IsError = false }).ToList();

            _results.Add(result);
        }

        public void CommandStatusChange(CommandStatusChangeObject obj)
        {
            var matchedCommandItem = _results.FirstOrDefault(p => p.CommandUniqueId == obj.CommandUniqueId);

            if (matchedCommandItem != null)
            {
                if (obj.IsError)
                {
                    Clients.Client(matchedCommandItem.ConnectionId).failure();
                    _results.Remove(matchedCommandItem);
                }
                else if (obj.IsFinished)
                {
                    var item = matchedCommandItem.EventResults.First(p => p.EventName == obj.EventName);

                    item.IsFinished = true;

                    if (matchedCommandItem.IsFinished)
                    {
                        Clients.Client(matchedCommandItem.ConnectionId).success();
                        _results.Remove(matchedCommandItem);
                    }
                }
            }
        }
    }
}