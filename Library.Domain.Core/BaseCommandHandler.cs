using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Library.Domain.Core.Models;

namespace Library.Domain.Core
{
    public abstract class BaseCommandHandler<T> : ICommandHandler<T> where T : ICommand
    {
        protected ICommandTracker _tracker = null;
        protected ILogger _logger = null;

        public BaseCommandHandler(ICommandTracker tracker, ILogger logger)
        {
            _tracker = tracker;
            _logger = logger;
        }

        public virtual void Dispose()
        {
            _tracker = null;
            _logger = null;
        }

        public abstract void Execute(T command);

        protected void AddCommandLog(CommonCommand command, string key, string message = "")
        {
            var attrs = Attribute.GetCustomAttributes(command.GetType(), typeof(CommandLogAttribute));

            if (attrs.Length > 0 && attrs.Any(x => (x is CommandLogAttribute) && ((CommandLogAttribute)x).Code == key))
            {
                var first = (CommandLogAttribute)attrs.First(x => ((CommandLogAttribute)x).Code == key);

                switch (first.Type)
                {
                    case LogType.Error:
                        _logger.CommandError(command, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");
                        break;
                    case LogType.Warning:
                        _logger.CommandWarning(command, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");
                        break;
                    case LogType.Info:
                        _logger.CommandInfo(command, first.Message);
                        break;
                    default:
                        break;
                }
            }
        }

        protected void AddCommandLogAndSendToTracker(CommonCommand command, string key, string message = "")
        {
            var attrs = Attribute.GetCustomAttributes(this.GetType().GetMethod("Execute"), typeof(CommandLogAttribute));

            if (attrs.Length > 0 && attrs.Any(x => (x is CommandLogAttribute) && ((CommandLogAttribute)x).Code == key))
            {
                var first = (CommandLogAttribute)attrs.First(x => ((CommandLogAttribute)x).Code == key);

                switch (first.Type)
                {
                    case LogType.Error:
                        _logger.CommandError(command, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");
                        _tracker.Error(command.CommandUniqueId, string.Empty, key, message);
                        break;
                    case LogType.Warning:
                        _logger.CommandWarning(command, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");
                        _tracker.Error(command.CommandUniqueId, string.Empty, key, message);
                        break;
                    case LogType.Info:
                        _logger.CommandInfo(command, first.Message);
                        break;
                    default:
                        break;
                }
            }

           
        }
    }
}
