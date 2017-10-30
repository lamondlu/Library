using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core.Messaging;

namespace BookingLibrary.Infrastructure.Messaging.SignalR
{
    public class SignalRCommandTracker : ICommandTracker
    {
        public SignalRCommandTracker()
        {

        }

        public void Track(Guid commandUniqueId, List<string> eventNames)
        {
            ApiRequest.Post("http://localhost:6044/api/monitored_commands", new { CommandUnqiueId = commandUniqueId, EventNames = eventNames });
        }

        public void Finish(Guid commandUniqueId, string eventName)
        {
            ApiRequest.Post($"http://localhost:6044/api/monitored_commands/{commandUniqueId}/events/{eventName}", new { Status = 0 });
        }

        public void Error(Guid commandUniqueId, string eventName)
        {
            ApiRequest.Post($"http://localhost:6044/api/monitored_commands/{commandUniqueId}/events/{eventName}", new { Status = 1 });
        }
    }
}
