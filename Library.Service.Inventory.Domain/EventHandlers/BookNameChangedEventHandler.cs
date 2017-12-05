using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookNameChangedEventHandler : BaseInventoryEventHandler<BookNameChangedEvent>
    {
        public BookNameChangedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(BookNameChangedEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookName(evt.AggregateId, evt.NewBookName);
                _reportDataAccessor.Commit();

                evt.Result(BookNameChangedEvent.Code_BOOKNAME_CHANGED);
            }
            catch (Exception ex)
            {
                evt.Result(BookNameChangedEvent.Code_SERVER_ERROR, ex.ToString());
            }
        }
    }
}