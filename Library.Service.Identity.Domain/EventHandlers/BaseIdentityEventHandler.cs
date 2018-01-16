using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Identity.Domain.DataAccessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service.Identity.Domain.EventHandlers
{
    public abstract class BaseIdentityEventHandler<T> : BaseEventHandler<T> where T : DomainEvent
    {
        protected IIdentityReportDataAccessor _reportDataAccessor = null;
        protected IDomainRepository _domainRepository = null;
        protected IEventPublisher _eventPublisher = null;

        public BaseIdentityEventHandler(IIdentityReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(commandTracker, logger)
        {
            _reportDataAccessor = reportDataAccessor;
            _domainRepository = domainRepository;
            _eventPublisher = eventPublisher;
        }
    }
}
