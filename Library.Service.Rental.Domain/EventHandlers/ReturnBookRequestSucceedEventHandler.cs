using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public class ReturnBookRequestSucceedEventHandler : BaseRentalEventHandler<ReturnBookRequestSucceedEvent>
    {
        public ReturnBookRequestSucceedEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(ReturnBookRequestSucceedEvent evt)
        {
            try
            {
                var customer = _domainRepository.GetById<Customer>(evt.CustomerId);
                customer.ReturnBook(evt.BookInventoryId);

                _domainRepository.Save(customer, customer.Version, evt.CommandUniqueId);
            }
            catch (Exception ex)
            {
                evt.Result(DomainEvent.Code_SERVER_ERROR, ex.ToString());
            }
        }
    }
}