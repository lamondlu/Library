using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Core.Models
{
    public class LoggerModel
    {
        public LoggerModel()
        {
            Id = Guid.NewGuid();
        }


        public Guid Id { get; set; }

        public LogType LoggerType { get; set; }

        public string CommandName { get; set; }

        public string CommandUniqueId { get; set; }

        public string EventName { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }

    public enum LogType
    {
        Info,
        Warning,
        Error
    }
}
