using Library.Domain.Core.Commands;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.DataAccessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service.Rental.Domain.CommandHandlers
{
    public abstract class BaseRentalCommandHandler<T> : ICommandHandler<T> where T : ICommand
    {
        protected IDomainRepository _domainRepository = null;
        protected IRentalReportDataAccessor _dataAccessor = null;
        protected ICommandTracker _tracker = null;
        protected ILogger _logger = null;
        protected IEventPublisher _eventPublisher = null;

        public BaseRentalCommandHandler(IDomainRepository domainRepository, IRentalReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger, IEventPublisher eventPublisher)
        {
            _domainRepository = domainRepository;
            _dataAccessor = dataAccesor;
            _tracker = tracker;
            _logger = logger;
            _eventPublisher = eventPublisher;
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
