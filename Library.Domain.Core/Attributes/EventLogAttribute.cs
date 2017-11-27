using Library.Domain.Core.Commands;
using Library.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CommandLogAttribute : Attribute
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public LogType Type { get; set; }
    }
}
