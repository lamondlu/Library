using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class ReturnBookRequestCreatedEventHandler : IEventHandler<ReturnBookRequestCreatedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;
        private IDomainRepository _domainRepository = null;
        private IEventPublisher _eventPublisher = null;

        public ReturnBookRequestCreatedEventHandler(IInventoryReportDataAccessor reportDataAccessor, IDomainRepository domainRepository, IEventPublisher eventPublisher)
        {
            _reportDataAccessor = reportDataAccessor;
            _domainRepository = domainRepository;
            _eventPublisher = eventPublisher;
        }

        public void Handle(ReturnBookRequestCreatedEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookInventoryStatus(evt.BookInventoryId, BookInventoryStatus.InStore, $"Return by {evt.Name.FirstName} {evt.Name.LastName} at {evt.ReturnDate.ToString("yyyy-MM-dd HH:mm:ss")}");
                _reportDataAccessor.Commit();

                _eventPublisher.Publish(new ReturnBookRequestSucceedEvent
                {
                    BookInventoryId = evt.BookInventoryId,
                    CustomerId = evt.AggregateId,
                    CommandUniqueId = evt.CommandUniqueId
                });
            }
            catch
            {
                //send event ReturnBookRequestFailedEvent
            }
        }

        public Task HandleAsync(ReturnBookRequestCreatedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}
