using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace BookLibrary.SignalR.Hubs
{
    public class CommandHub : Hub
    {
        private static List<CommandResult> _results = null;

        static CommandHub()
        {
            _results = new List<Hubs.CommandResult>();
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

    public class MonitorObject
    {
        public Guid CommandUniqueId { get; set; }

        public List<string> EventNames { get; set; }
    }

    public class CommandStatusChangeObject
    {
        public Guid CommandUniqueId { get; set; }

        public string EventName { get; set; }

        public bool IsFinished { get; set; }

        public bool IsError { get; set; }
    }

    public class CommandResult
    {
        public CommandResult()
        {
            EventResults = new List<Hubs.EventResult>();
        }

        public Guid CommandUniqueId { get; set; }

        public string ConnectionId { get; set; }

        public List<EventResult> EventResults { get; set; }

        public bool IsFinished
        {
            get
            {
                return EventResults.Count != 0 && EventResults.All(p => p.IsFinished);
            }
        }

        public bool IsError
        {
            get
            {
                return EventResults.Any(p => p.IsError);
            }
        }
    }

    public class EventResult
    {
        public string EventName { get; set; }

        public bool IsFinished { get; set; }

        public bool IsError { get; set; }
    }
}