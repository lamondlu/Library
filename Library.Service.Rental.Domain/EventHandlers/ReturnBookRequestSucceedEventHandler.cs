using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public class ReturnBookRequestSucceedEventHandler : Library.Domain.Core.IEventHandler<ReturnBookRequestSucceedEvent>
    {
        private IDomainRepository _domainRepository = null;
        private ILogger _logger = null;

        public ReturnBookRequestSucceedEventHandler(IDomainRepository domainRepository, ILogger logger)
        {
            _domainRepository = domainRepository;
            _logger = logger;
        }

        public void Handle(ReturnBookRequestSucceedEvent evt)
        {
            try
            {
                var customer = _domainRepository.GetById<Customer>(evt.CustomerId);
                customer.ReturnBook(evt.BookInventoryId);

                _domainRepository.Save(customer, customer.Version, evt.CommandUniqueId);
                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                //Send compensation event to make the book outstore again.

                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
            }
        }

        public Task HandleAsync(ReturnBookRequestSucceedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}
