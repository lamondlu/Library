using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookIssuedDatehangedEventHandler : BaseInventoryEventHandler<BookIssuedDateChangedEvent>
    {
        public BookIssuedDatehangedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(BookIssuedDateChangedEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookIssuedDate(evt.AggregateId, evt.NewBookIssuedDate);
                _reportDataAccessor.Commit();

                evt.Result(BookIssuedDateChangedEvent.Code_BOOKISSUEDDATE_CHANGED);
            }
            catch (Exception ex)
            {
                evt.Result(BookIssuedDateChangedEvent.Code_SERVER_ERROR, ex.ToString());
            }
        }
    }
}