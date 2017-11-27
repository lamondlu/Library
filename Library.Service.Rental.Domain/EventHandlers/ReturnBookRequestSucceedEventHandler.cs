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

        public override void Handle(ReturnBookRequestSucceedEvent evt)
        {
            try
            {
                var customer = _domainRepository.GetById<Customer>(evt.CustomerId);
                customer.ReturnBook(evt.BookInventoryId);

                _domainRepository.Save(customer, customer.Version, evt.CommandUniqueId);
                _logger.EventInfo(evt, "Event Finished.");

                AddEventLog(evt, "RETURNBOOKREQUEST_SUCCEED");
            }
            catch (Exception ex)
            {
                //Send compensation event to make the book outstore again.
                AddEventLog(evt, "SERVER_ERROR", ex.ToString());
            }
        }
    }
}