using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Inventory.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core.Messaging;
using BookingLibrary.Domain.Core.DataAccessor;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
{
    public class RentedBookOutStoredEventHandler : IEventHandler<RentedBookOutStoredEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;
        private IDomainRepository _domainRepository = null;
        private IEventPublisher _eventPublisher = null;

        public RentedBookOutStoredEventHandler(IInventoryReportDataAccessor reportDataAccessor, IDomainRepository domainRepository, IEventPublisher eventPublisher)
        {
            _reportDataAccessor = reportDataAccessor;
            _domainRepository = domainRepository;
            _eventPublisher = eventPublisher;
        }

        public void Handle(RentedBookOutStoredEvent evt)
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
            }
            catch
            {

            }
        }

        public Task HandleAsync(RentedBookOutStoredEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}
