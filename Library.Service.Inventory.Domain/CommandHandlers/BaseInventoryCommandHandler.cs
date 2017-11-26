using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service.Inventory.Domain.CommandHandlers
{
    public abstract class BaseInventoryCommandHandler<T> : ICommandHandler<T> where T : ICommand
    {
        protected IDomainRepository _domainRepository = null;
        protected IInventoryReportDataAccessor _dataAccessor = null;
        protected ICommandTracker _tracker = null;
        protected ILogger _logger = null;

        public BaseInventoryCommandHandler(IDomainRepository domainRepository, IInventoryReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger)
        {
            _domainRepository = domainRepository;
            _dataAccessor = dataAccesor;
            _tracker = tracker;
            _logger = logger;
        }


        public virtual void Dispose()
        {
            _domainRepository = null;
            _dataAccessor = null;
            _tracker = null;
            _logger = null;
        }

        public abstract void Execute(T command);
    }
}
