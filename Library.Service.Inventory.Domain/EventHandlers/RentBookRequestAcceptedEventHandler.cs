using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class RentBookRequestAcceptedEventHandler : BaseInventoryEventHandler<RentBookRequestAcceptedEvent>
    {
        public RentBookRequestAcceptedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(RentBookRequestAcceptedEvent evt)
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

                evt.Result("RENTBOOKREQUEST_ACCEPTED");
            }
            catch (Exception ex)
            {
                //publish an RentBookRequestFailedEvent

                evt.Result("SERVER_ERROR", ex.ToString());
            }
        }
    }
}