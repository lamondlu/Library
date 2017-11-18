using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Service.Rental.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain.EventHandlers
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
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