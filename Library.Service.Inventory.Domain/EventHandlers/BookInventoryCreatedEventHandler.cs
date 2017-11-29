using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookInventoryCreatedEventHandler : BaseInventoryEventHandler<BookInventoryCreatedEvent>
    {
        public BookInventoryCreatedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(BookInventoryCreatedEvent evt)
        {
            try
            {
                _reportDataAccessor.AddBookInventory(evt.BookId, evt.AggregateId, BookInventoryStatus.InStore, evt.Notes);
                _reportDataAccessor.Commit();

                evt.Result("BOOKINVENTORY_CREATED");
            }
            catch (Exception ex)
            {
                evt.Result("SERVER_ERROR", ex.ToString());
            }
        }
    }
}