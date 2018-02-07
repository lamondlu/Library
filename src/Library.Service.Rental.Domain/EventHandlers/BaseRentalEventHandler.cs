using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.DataAccessors;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public abstract class BaseRentalEventHandler<T> : BaseEventHandler<T> where T : DomainEvent
    {
        protected IRentalReportDataAccessor _reportDataAccessor = null;
        protected IDomainRepository _domainRepository = null;
        protected IEventPublisher _eventPublisher = null;

        public BaseRentalEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(commandTracker, logger)
        {
            _reportDataAccessor = reportDataAccessor;
            _domainRepository = domainRepository;
            _eventPublisher = eventPublisher;
        }
    }
}