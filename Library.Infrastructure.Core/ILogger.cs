using Library.Infrastructure.Core.Models;
using System;

namespace Library.Infrastructure.Core
{
    public interface ILogger
    {
        void Success(Guid commandUnqiueId, string commandName, string eventName, string message, string data);

        void Error(Guid commandUniqueId, string commandName, string eventName, string message, string data);

        void Info(Guid commandUniqueId, string commandName, string eventName, string message, string data);
    }
}
