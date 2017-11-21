using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class RentBookRequestAcceptedEventHandler : IEventHandler<RentBookRequestAcceptedEvent>
    {
        private IDomainRepository _domainRepository = null;
        private IEventPublisher _eventPublisher = null;
        private ILogger _logger = null;

        public RentBookRequestAcceptedEventHandler(IDomainRepository domainRepository, IEventPublisher eventPublisher, ILogger logger)
        {
            _domainRepository = domainRepository;
            _eventPublisher = eventPublisher;
            _logger = logger;
        }

        public void Handle(RentBookRequestAcceptedEvent evt)
        {
            var bookInventory = _domainRepository.GetById<BookInventory>(evt.AggregateId);

            try
            {
                if (bookInventory.Status == BookInventoryStatus.OutStore)
                {
                    _eventPublisher.Publish(new BookInventoryOutputFailedEvent
                    {
                        CommandUniqueId = evt.CommandUniqueId
                    });
                }
                else
                {
                    bookInventory.RentedBookOutStore(evt.CustomerId, evt.Notes);
                    _domainRepository.Save(bookInventory, bookInventory.Version, evt.CommandUniqueId);
                }

                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                //publish an RentBookRequestFailedEvent

                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
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