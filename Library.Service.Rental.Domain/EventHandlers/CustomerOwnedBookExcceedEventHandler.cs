using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public class CustomerOwnedBookExcceedEventHandler : BaseRentalEventHandler<CustomerOwnedBookExcceedEvent>
    {
        public CustomerOwnedBookExcceedEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {

        }

        public override void Handle(CustomerOwnedBookExcceedEvent evt)
        {
            try
            {
                _commandTracker.DirectError(evt.CommandUniqueId, "Error_CustomerOwnedBookExcceed", "One customer can only have 3 books at most.");
                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
            }
        }
    }
}