using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookInventoryInStoredEventHandler : BaseInventoryEventHandler<BookInventoryInStoredEvent>
    {
        public BookInventoryInStoredEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(BookInventoryInStoredEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookInventoryStatus(evt.AggregateId, BookInventoryStatus.InStore, evt.Notes, evt.InStoreDate);
                _reportDataAccessor.Commit();

                evt.Result(BookInventoryInStoredEvent.Code_BOOKINVENTORY_INSTORED);
            }
            catch (Exception ex)
            {
                evt.Result(BookInventoryInStoredEvent.Code_SERVER_ERROR, ex.ToString());
            }
        }
    }
}