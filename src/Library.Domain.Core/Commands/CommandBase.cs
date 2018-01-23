using System;

namespace Library.Domain.Core.Commands
{
	public class CommandBase : ICommand
	{
		private string _commandKey;
		private string _resultCode = string.Empty;
		private string _extraMessage = string.Empty;

		private Guid _commandUniqueId;

		public string CommandKey
		{
			get
			{
				return _commandKey;
			}
		}

		public Guid CommandUniqueId
		{
			get
			{
				return _commandUniqueId;
			}
			set
			{
				_commandUniqueId = value;
			}
		}

		public string CommandResult
		{
			get
			{
				return _resultCode;
			}
		}

		public string ExtraMessage
		{
			get
			{
				return _extraMessage;
			}
		}

		public CommandBase(string key)
		{
			_commandKey = key;
			_commandUniqueId = Guid.NewGuid();
		}

		public void Result(string code, string extraMessage = "")
		{
			_resultCode = code;
			_extraMessage = extraMessage;
		}
	}
}