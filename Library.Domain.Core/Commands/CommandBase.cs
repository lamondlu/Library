using System;

namespace Library.Domain.Core.Commands
{
    public class CommandBase : ICommand
    {
        private string _commandKey;

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

        public CommandBase(string key)
        {
            _commandKey = key;
            _commandUniqueId = Guid.NewGuid();
        }
    }
}