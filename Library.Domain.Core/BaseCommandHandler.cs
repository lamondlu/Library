using Library.Domain.Core.Attributes;
using Library.Domain.Core.Commands;
using Library.Domain.Core.Messaging;
using Library.Domain.Core.Models;
using System;
using System.Linq;

namespace Library.Domain.Core
{
	public abstract class BaseCommandHandler<T> : ICommandHandler<T> where T : CommonCommand
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

		public void Execute(T command)
		{
			ExecuteCore(command);
			AddCommandLog(command, command.CommandResult, command.ExtraMessage);
		}

		public abstract void ExecuteCore(T command);

		private void AddCommandLog(T command, string key, string message = "")
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

				if (first.SendError)
				{
					_tracker.Error(command.CommandUniqueId, string.Empty, key, message);
				}

				if (first.SendFinish)
				{
					_tracker.DirectFinish(command.CommandUniqueId);
				}
			}
		}
	}
}