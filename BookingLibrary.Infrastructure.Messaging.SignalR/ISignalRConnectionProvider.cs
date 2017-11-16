using System;
using System.Collections.Generic;
using System.Text;

namespace BookingLibrary.Infrastructure.Messaging.SignalR
{
    public interface ISignalRConnectionProvider
    {
        string Url { get; }
    }
}
