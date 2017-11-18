using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Service.Rental.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public class ReturnBookRequestSucceedEventHandler : IEventHandler<ReturnBookRequestSucceedEvent>
    {
        private IDomainRepository _domainRepository = null;

        public ReturnBookRequestSucceedEventHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public void Handle(ReturnBookRequestSucceedEvent evt)
        {
            try
            {
                var customer = _domainRepository.GetById<Customer>(evt.CustomerId);
                customer.ReturnBook(evt.BookInventoryId);

                _domainRepository.Save(customer, customer.Version, evt.CommandUniqueId);
            }
            catch
            {
                //Send compensation event to make the book outstore again.
            }
        }

        public Task HandleAsync(ReturnBookRequestSucceedEvent evt)
        {
            throw new NotImplementedException();
        }
    }
}
