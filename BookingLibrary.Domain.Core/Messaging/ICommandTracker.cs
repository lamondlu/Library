using System;
using System.Collections.Generic;

namespace BookingLibrary.Domain.Core.Messaging
{
    public interface ICommandTracker
    {
        void Track(Guid commandUniqueId, List<string> eventNames);

        void Finish(Guid commandUniqueId, string eventName);

        void Error(Guid commandUniqueId, string eventName,string errorCode, string errorMessage);
    }
}