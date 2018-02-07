using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class RentedBookOutStoredEventHandler : BaseInventoryEventHandler<RentedBookOutStoredEvent>
    {
        public RentedBookOutStoredEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(RentedBookOutStoredEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookInventoryStatus(evt.AggregateId, BookInventoryStatus.OutStore, evt.Notes, evt.OccurredOn);
                _reportDataAccessor.Commit();

                _eventPublisher.Publish(new BookRentedEvent
                {
                    CommandUniqueId = evt.CommandUniqueId,
                    CustomerId = evt.CustomerId,
                    BookInventoryId = evt.AggregateId,
					AggregateId = evt.AggregateId
                });

                evt.Result(RentedBookOutStoredEvent.Code_RENTEDBOOK_OUTSTORED);
            }
            catch (Exception ex)
            {
                evt.Result(RentedBookOutStoredEvent.Code_SERVER_ERROR, ex.ToString());
            }
        }
    }
}