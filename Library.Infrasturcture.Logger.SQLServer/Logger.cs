using Library.Infrastructure.Core;
using System;

namespace Library.Infrasturcture.Logger.Log4Net
{
    public class Logger : ILogger
    {
        public Logger()
        {

        }

        public void Error(string commandUniqueId, string commandName, string eventName, string message)
        {
            throw new NotImplementedException();
        }

        public void Info(string commandUniqueId, string commandName, string eventName, string message)
        {
            throw new NotImplementedException();
        }

        public void Success(string commandUnqiueId, string commandName, string eventName, string message)
        {
            throw new NotImplementedException();
        }
    }
}
