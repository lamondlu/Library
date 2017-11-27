using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public abstract class BaseInventoryEventHandler<T> : BaseEventHandler<T> where T : DomainEvent
    {
        protected IInventoryReportDataAccessor _reportDataAccessor = null;
        protected IDomainRepository _domainRepository = null;
        protected IEventPublisher _eventPublisher = null;

        public BaseInventoryEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher): base(commandTracker, logger)
        {
            _reportDataAccessor = reportDataAccessor;
            _domainRepository = domainRepository;
            _eventPublisher = eventPublisher;
        }
    }
}
