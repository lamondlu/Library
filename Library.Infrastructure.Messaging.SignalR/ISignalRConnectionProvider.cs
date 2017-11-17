using System;
using System.Collections.Generic;
using System.Text;

namespace  Library.Infrastructure.Messaging.SignalR
{
    public interface ISignalRConnectionProvider
    {
        string Url { get; }
    }
}
