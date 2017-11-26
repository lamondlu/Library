using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class ReturnBookRequestCreatedEventHandler : BaseEventHandler<ReturnBookRequestCreatedEvent>
    {
        public ReturnBookRequestCreatedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {

        }

        public override void Handle(ReturnBookRequestCreatedEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookInventoryStatus(evt.BookInventoryId, BookInventoryStatus.InStore, $"Return by {evt.Name.FirstName} {evt.Name.LastName} at {evt.ReturnDate.ToString("yyyy-MM-dd HH:mm:ss")}");
                _reportDataAccessor.Commit();

                _eventPublisher.Publish(new ReturnBookRequestSucceedEvent
                {
                    BookInventoryId = evt.BookInventoryId,
                    CustomerId = evt.AggregateId,
                    CommandUniqueId = evt.CommandUniqueId
                });

                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                //send event ReturnBookRequestFailedEvent

                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
            }
        }
    }
}
