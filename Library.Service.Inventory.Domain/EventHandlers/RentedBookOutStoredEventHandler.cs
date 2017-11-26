using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class RentedBookOutStoredEventHandler : BaseInventoryEventHandler<RentedBookOutStoredEvent>
    {
        public RentedBookOutStoredEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {

        }

        public override void Handle(RentedBookOutStoredEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookInventoryStatus(evt.AggregateId, BookInventoryStatus.OutStore, evt.Notes);
                _reportDataAccessor.Commit();

                var rentBookRequestSucceedEvent = new RentBookRequestSucceedEvent
                {
                    CommandUniqueId = evt.CommandUniqueId,
                    BookInventoryId = evt.AggregateId,
                    CustomerId = evt.CustomerId,
                    AggregateId = evt.AggregateId
                };

                _eventPublisher.Publish(rentBookRequestSucceedEvent);
                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
            }
        }
    }
}