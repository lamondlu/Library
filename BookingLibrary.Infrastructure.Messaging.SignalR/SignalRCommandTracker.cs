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
            ApiRequest.Post("http://localhost:6044/api/monitored_commands", new
            {
                CommandUniqueId = commandUniqueId,
                EventNames = eventNames
            });
        }

        public void Finish(Guid commandUniqueId, string eventName)
        {
            ApiRequest.Put($"http://localhost:6044/api/monitored_commands/{commandUniqueId}/events/{eventName}", new { Status = "0" });
        }

        public void Error(Guid commandUniqueId, string eventName, string errorCode, string errorMessage)
        {
            var data = new NameValueCollection();
            data.Add("Status", "1");
            data.Add("ErrorCode", errorCode);
            data.Add("ErrorMessage", errorMessage);

            if (string.IsNullOrEmpty(eventName))
            {
                ApiRequest.Put($"http://localhost:6044/api/monitored_commands/{commandUniqueId}", new
                {
                    Status = "1",
                    ErrorCode = errorCode,
                    ErrorMessage = errorMessage
                });
            }
            else
            {
                ApiRequest.Put($"http://localhost:6044/api/monitored_commands/{commandUniqueId}/events/{eventName}", new
                {
                    Status = "1",
                    ErrorCode = errorCode,
                    ErrorMessage = errorMessage
                });
            }

        }
    }
}
