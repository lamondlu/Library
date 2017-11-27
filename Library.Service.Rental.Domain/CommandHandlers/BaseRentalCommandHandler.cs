using Library.Domain.Core;
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
    public abstract class BaseRentalCommandHandler<T> : BaseCommandHandler<T> where T : ICommand
    {
        protected IDomainRepository _domainRepository = null;
        protected IRentalReportDataAccessor _dataAccessor = null;
        protected IEventPublisher _eventPublisher = null;

        public BaseRentalCommandHandler(IDomainRepository domainRepository, IRentalReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger, IEventPublisher eventPublisher) : base(tracker, logger)
        {
            _domainRepository = domainRepository;
            _dataAccessor = dataAccesor;
            _eventPublisher = eventPublisher;
        }


        public override void Dispose()
        {
            _domainRepository = null;
            _dataAccessor = null;
            _eventPublisher = null;

            base.Dispose();
        }
    }
}
