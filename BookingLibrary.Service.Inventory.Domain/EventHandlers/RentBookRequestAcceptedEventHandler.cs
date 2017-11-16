using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Inventory.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core.Messaging;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
{
    public class RentBookRequestAcceptedEventHandler : IEventHandler<RentBookRequestAcceptedEvent>
    {
        private IDomainRepository _domainRepository = null;
        private IEventPublisher _eventPublisher = null;

        public RentBookRequestAcceptedEventHandler(IDomainRepository domainRepository, IEventPublisher eventPublisher)
        {
            _domainRepository = domainRepository;
            _eventPublisher = eventPublisher;
        }

        public void Handle(RentBookRequestAcceptedEvent evt)
        {
            var bookInventory = _domainRepository.GetById<BookInventory>(evt.AggregateId);

            try
            {
                if (bookInventory.Status == BookInventoryStatus.OutStore)
                {
                    _eventPublisher.Publish(new BookInventoryOutputFailedEvent{
                        CommandUniqueId = evt.CommandUniqueId
                    });
                }
                else
                {
                    bookInventory.RentedBookOutStore(evt.CustomerId, evt.Notes);
                    _domainRepository.Save(bookInventory, bookInventory.Version, evt.CommandUniqueId);
                }
            }
            catch
            {
                //publish an RentBookRequestFailedEvent
            }
        }

        public Task HandleAsync(RentBookRequestAcceptedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}
