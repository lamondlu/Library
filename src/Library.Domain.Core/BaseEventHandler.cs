using Library.Domain.Core.Attributes;
using Library.Domain.Core.Messaging;
using Library.Domain.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

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

		public void Handle(T evt)
		{
			HandleCore(evt);

			AddEventLog(evt, evt.EventResult, evt.ExtraMessage);
		}

		public abstract void HandleCore(T evt);

		public Task HandleAsync(T evt)
		{
			return Task.Factory.StartNew(() =>
			{
				HandleCore(evt);
			});
		}

		private void AddEventLog(T evt, string key, string message = "")
		{
			var attrs = Attribute.GetCustomAttributes(evt.GetType(), typeof(EventLogAttribute));

			if (attrs.Length > 0 && attrs.Any(x => (x is EventLogAttribute) && ((EventLogAttribute)x).Code == key))
			{
				var first = (EventLogAttribute)attrs.First(x => ((EventLogAttribute)x).Code == key);

				switch (first.Type)
				{
					case LogType.Error:
						_logger.EventError(evt, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");

						if (first.SendFinish)
						{
							_commandTracker.DirectFinish(evt.CommandUniqueId);
						}
						if (first.SendError)
						{
							_commandTracker.DirectError(evt.CommandUniqueId, key, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");
						}

						break;

					case LogType.Warning:
						_logger.EventWarning(evt, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");

						if (first.SendFinish)
						{
							_commandTracker.DirectFinish(evt.CommandUniqueId);
						}

						if (first.SendError)
						{
							_commandTracker.DirectError(evt.CommandUniqueId, key, $"{first.Code}:{(!string.IsNullOrEmpty(message) ? message : first.Message)}");
						}

						break;

					case LogType.Info:
						_logger.EventInfo(evt, first.Message);

						if (first.SendFinish)
						{
							_commandTracker.DirectFinish(evt.CommandUniqueId);
						}

						if (first.SendError)
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