using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Identity.Domain.DataAccessors;
using Library.Service.Identity.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Identity.Domain.EventHandlers
{
    public class RentBookRequestCreatedEventHandler : BaseIdentityEventHandler<RentBookRequestCreatedEvent>
    {
        public RentBookRequestCreatedEventHandler(IIdentityReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(RentBookRequestCreatedEvent evt)
        {
            var customer = _domainRepository.GetById<User>(evt.AggregateId);

            if (customer.Books.Count > 0)
            {
                evt.Result(RentBookRequestCreatedEvent.Code_OWNED_BOOK_EXCCEED);
                _commandTracker.DirectError(evt.CommandUniqueId, RentBookRequestCreatedEvent.Code_OWNED_BOOK_EXCCEED, "One customer can only have 3 book at most.");
            }
            else
            {
                _eventPublisher.Publish(new RentBookRequestAcceptedEvent
                {
                    AggregateId = evt.BookInventoryId,
                    CommandUniqueId = evt.CommandUniqueId,
                    Notes = $"Rent by {evt.Name.FirstName} {evt.Name.LastName} at {evt.RentDate.ToString("yyyy-MM-dd HH:mm:ss")}",
                    CustomerId = evt.AggregateId
                });

                evt.Result(RentBookRequestCreatedEvent.Code_RENTBOOKREQUEST_CREATED);
            }
        }
    }
}
