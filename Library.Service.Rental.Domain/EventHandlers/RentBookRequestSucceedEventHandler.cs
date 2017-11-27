using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.Events;
using System;
using System.Threading.Tasks;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Domain.Core.Messaging;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public class RentBookRequestSucceedEventHandler : BaseRentalEventHandler<RentBookRequestSucceedEvent>
    {
        public RentBookRequestSucceedEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher){

        }

        public override void Handle(RentBookRequestSucceedEvent evt)
        {
            try
            {
                var customer = _domainRepository.GetById<Customer>(evt.CustomerId);
                customer.RentBook(evt.BookInventoryId);
                _domainRepository.Save(customer, customer.Version, evt.CommandUniqueId);

                AddEventLog(evt, "RENTBOOKREQUEST_SUCCEED");
            }
            catch (Exception ex)
            {
                AddEventLog(evt, "SERVER_ERROR", ex.ToString());
                //publish RentBookFailedEvent
            }
        }
    }
}