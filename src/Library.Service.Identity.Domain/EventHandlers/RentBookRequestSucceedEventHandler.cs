using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Identity.Domain.DataAccessors;
using Library.Service.Identity.Domain.Events;
using System;

namespace Library.Service.Identity.Domain.EventHandlers
{
	public class RentBookRequestSucceedEventHandler : BaseIdentityEventHandler<RentBookRequestSucceedEvent>
	{
		public RentBookRequestSucceedEventHandler(IIdentityReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
		{
		}

		public override void HandleCore(RentBookRequestSucceedEvent evt)
		{
			try
			{
				var customer = _domainRepository.GetById<User>(evt.CustomerId);
				customer.OwnBook(evt.BookInventoryId);
				_domainRepository.Save(customer, customer.Version, evt.CommandUniqueId);

				evt.Result(RentBookRequestSucceedEvent.Code_RENTBOOKREQUEST_SUCCEED);
			}
			catch (Exception ex)
			{
				evt.Result(DomainEvent.Code_SERVER_ERROR, ex.ToString());
			}
		}
	}
}