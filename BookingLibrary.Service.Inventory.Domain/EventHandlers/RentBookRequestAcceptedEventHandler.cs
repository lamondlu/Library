using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Inventory.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
{
    public class RentBookRequestAcceptedEventHandler : IEventHandler<RentBookRequestAcceptedEvent>
    {
        private IDomainRepository _domainRepository = null;

        public RentBookRequestAcceptedEventHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public void Handle(RentBookRequestAcceptedEvent evt)
        {
            var bookInventory = _domainRepository.GetById<BookInventory>(evt.AggregateId);

            try
            {
                bookInventory.RentedBookOutStore(evt.CustomerId, evt.Notes);
                _domainRepository.Save(bookInventory, bookInventory.Version, evt.CommandUniqueId);
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
