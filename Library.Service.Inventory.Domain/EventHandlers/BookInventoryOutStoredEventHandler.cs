using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookInventoryOutStoredEventHandler : BaseInventoryEventHandler<BookInventoryOutStoredEvent>
    {
        public BookInventoryOutStoredEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(BookInventoryOutStoredEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookInventoryStatus(evt.AggregateId, BookInventoryStatus.OutStore, evt.Notes, evt.OutStoreDate);
                _reportDataAccessor.Commit();

                evt.Result("BOOKINVENTORY_OUTSTORED");
            }
            catch (Exception ex)
            {
                evt.Result("SERVER_ERROR", ex.ToString());
            }
        }
    }
}