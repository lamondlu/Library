using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.EventHandlers;

namespace Library.Service.Rental.Domain
{
	public class CustomerAccountInitializedEventHandler : BaseRentalEventHandler<CustomerAccountInitializedEvent>
	{
		public CustomerAccountInitializedEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
		{
		}

		public override void HandleCore(CustomerAccountInitializedEvent evt)
		{
			evt.Result(CustomerAccountInitializedEvent.Code_CUSTOMERACCOUNT_INITIALIZED);
		}
	}
}