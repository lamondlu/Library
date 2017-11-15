using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.DataAccessor;
using BookingLibrary.Service.Rental.Domain.DataAccessors;
using BookingLibrary.Service.Rental.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Service.Rental.Domain.EventHandlers
{
    public class RentBookRequestSucceedEventHandler : IEventHandler<RentBookRequestSucceedEvent>
    {
        private IDomainRepository _domainRepository = null;

        public RentBookRequestSucceedEventHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public void Handle(RentBookRequestSucceedEvent evt)
        {
            try
            {
                var customer = _domainRepository.GetById<Customer>(evt.CustomerId);
                customer.RentBook(evt.BookInventoryId);
                _domainRepository.Save(customer, customer.Version, evt.CommandUniqueId);
            }
            catch
            {
                //publish RentBookFailedEvent
            }
        }

        public Task HandleAsync(RentBookRequestSucceedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}
