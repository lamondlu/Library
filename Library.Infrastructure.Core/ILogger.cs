using Library.Infrastructure.Core.Models;
using System;

namespace Library.Infrastructure.Core
{
    public interface ILogger
    {
        void Success(string commandUnqiueId, string commandName, string eventName, string message);

        void Error(string commandUniqueId, string commandName, string eventName, string message);

        void Info(string commandUniqueId, string commandName, string eventName, string message);
    }
}
