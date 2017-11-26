using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.EventHandlers;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain
{
    public class CustomerAccountInitializedEventHandler : BaseRentalEventHandler<CustomerAccountInitializedEvent>
    {
        public CustomerAccountInitializedEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {

        }

        public override void Handle(CustomerAccountInitializedEvent evt)
        {
            _logger.EventInfo(evt, "Event Finished.");
        }
    }
}