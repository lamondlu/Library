using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public class RentBookRequestSucceedEventHandler : Library.Domain.Core.IEventHandler<RentBookRequestSucceedEvent>
    {
        private IDomainRepository _domainRepository = null;
        private ILogger _logger = null;

        public RentBookRequestSucceedEventHandler(IDomainRepository domainRepository, ILogger logger)
        {
            _domainRepository = domainRepository;
            _logger = logger;
        }

        public void Handle(RentBookRequestSucceedEvent evt)
        {
            try
            {
                var customer = _domainRepository.GetById<Customer>(evt.CustomerId);
                customer.RentBook(evt.BookInventoryId);
                _domainRepository.Save(customer, customer.Version, evt.CommandUniqueId);

                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
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