using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core.Messaging;
using System.Collections.Specialized;

namespace BookingLibrary.Infrastructure.Messaging.SignalR
{
    public class SignalRCommandTracker : ICommandTracker
    {
        public SignalRCommandTracker()
        {

        }

        public void Track(Guid commandUniqueId, List<string> eventNames)
        {
            var data = new NameValueCollection();
            data.Add("CommandUniqueId", commandUniqueId.ToString());
            data.Add("EventNames", string.Join(",", eventNames));

            ApiRequest.Post("http://localhost:6044/api/monitored_commands", data);
        }

        public void Finish(Guid commandUniqueId, string eventName)
        {
            var data = new NameValueCollection();
            data.Add("Status", "0");

            ApiRequest.Put($"http://localhost:6044/api/monitored_commands/{commandUniqueId}/events/{eventName}", data);
        }

        public void Error(Guid commandUniqueId, string eventName)
        {
            var data = new NameValueCollection();
            data.Add("Status", "1");

            ApiRequest.Put($"http://localhost:6044/api/monitored_commands/{commandUniqueId}/events/{eventName}", data);
        }
    }
}
