using BookLibrary.Domain.Core;
using BookLibrary.Service.Inventory.Domain.DataAccessors;
using BookLibrary.Service.Inventory.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Domain.Core.Messaging;
using BookLibrary.Domain.Core.DataAccessor;

namespace BookLibrary.Service.Inventory.Domain.EventHandlers
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
