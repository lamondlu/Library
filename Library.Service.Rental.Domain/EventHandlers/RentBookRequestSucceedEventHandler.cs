using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public class RentBookRequestSucceedEventHandler : BaseRentalEventHandler<RentBookRequestSucceedEvent>
    {
        public RentBookRequestSucceedEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(RentBookRequestSucceedEvent evt)
        {
            try
            {
                var customer = _domainRepository.GetById<Customer>(evt.CustomerId);
                customer.RentBook(evt.BookInventoryId);
                _domainRepository.Save(customer, customer.Version, evt.CommandUniqueId);

                evt.Result("RENTBOOKREQUEST_SUCCEED");
            }
            catch (Exception ex)
            {
                evt.Result("SERVER_ERROR", ex.ToString());
            }
        }
    }
}