using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class ReturnBookRequestCreatedEventHandler : BaseInventoryEventHandler<ReturnBookRequestCreatedEvent>
    {
        public ReturnBookRequestCreatedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(ReturnBookRequestCreatedEvent evt)
        {
            try
            {
                var bookInventory = _domainRepository.GetById<BookInventory>(evt.BookInventoryId);
                bookInventory.InStore($"Return by {evt.Name.FirstName} {evt.Name.LastName} at {evt.ReturnDate.ToString("yyyy-MM-dd HH:mm:ss")}", evt.OccurredOn);
                _domainRepository.Save(bookInventory, bookInventory.Version, evt.CommandUniqueId);

                _eventPublisher.Publish(new ReturnBookRequestSucceedEvent
                {
                    BookInventoryId = evt.BookInventoryId,
                    CustomerId = evt.AggregateId,
                    CommandUniqueId = evt.CommandUniqueId
                });
            }
            catch (Exception ex)
            {
                //send event ReturnBookRequestFailedEvent

                evt.Result(ReturnBookRequestCreatedEvent.Code_SERVER_ERROR, ex.ToString());
            }
        }
    }
}