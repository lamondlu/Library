using Library.Domain.Core.Attributes;
using Library.Domain.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Library.Domain.Core.Models;

namespace Library.Domain.Core
{
    public abstract class BaseEventHandler<T> : IEventHandler<T> where T : DomainEvent
    {
        protected ICommandTracker _commandTracker = null;
        protected ILogger _logger = null;

        public BaseEventHandler(ICommandTracker commandTracker, ILogger logger)
        {
            _commandTracker = commandTracker;
            _logger = logger;
        }

        public abstract void Handle(T evt);

        public Task HandleAsync(T evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }

        public void AddEventLog(T evt, string key, string message = "")
        {
            var attrs = Attribute.GetCustomAttributes(evt.GetType(), typeof(EventLogAttribute));

            if (attrs.Length > 0 && attrs.Any(x => (x is EventLogAttribute) && ((EventLogAttribute)x).Code == key))
            {
                var first = (EventLogAttribute)attrs.First(x => ((EventLogAttribute)x).Code == key);

                switch (first.Type)
                {
                    case LogType.Error:
                        _logger.EventError(evt, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");
                        break;
                    case LogType.Warning:
                        _logger.EventWarning(evt, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");
                        break;
                    case LogType.Info:
                        _logger.EventInfo(evt, first.Message);
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddEventLogAndSendToTracker(T evt, string key, string message = "")
        {
            var attrs = Attribute.GetCustomAttributes(this.GetType().GetMethod("Handle"), typeof(EventLogAttribute));

            if (attrs.Length > 0 && attrs.Any(x => (x is EventLogAttribute) && ((EventLogAttribute)x).Code == key))
            {
                var first = (EventLogAttribute)attrs.First(x => ((EventLogAttribute)x).Code == key);

                switch (first.Type)
                {
                    case LogType.Error:
                        _logger.EventError(evt, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");

                        if (first.DirectFinish)
                        {
                            _commandTracker.DirectFinish(evt.CommandUniqueId);
                        }
                        if (first.DirectError)
                        {
                            _commandTracker.DirectError(evt.CommandUniqueId, key, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");
                        }

                        break;
                    case LogType.Warning:
                        _logger.EventWarning(evt, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");


                        if (first.DirectFinish)
                        {
                            _commandTracker.DirectFinish(evt.CommandUniqueId);
                        }

                        if (first.DirectError)
                        {
                            _commandTracker.DirectError(evt.CommandUniqueId, key, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");
                        }

                        break;
                    case LogType.Info:
                        _logger.EventInfo(evt, first.Message);

                        if (first.DirectFinish)
                        {
                            _commandTracker.DirectFinish(evt.CommandUniqueId);
                        }

                        if (first.DirectError)
                        {
                            _commandTracker.DirectError(evt.CommandUniqueId, key, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }

}
