using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Identity.Domain.DataAccessors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Identity.Domain.EventHandlers
{
	public class UserCreatedEventHandler : BaseIdentityEventHandler<UserCreatedEvent>
	{
		public UserCreatedEventHandler(IIdentityReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
		{

		}

		public override void HandleCore(UserCreatedEvent evt)
		{
			try
			{
				_reportDataAccessor.CreateUser(evt.AggregateId, evt.Principal.UserName, evt.Principal.Password, evt.PersonName.FirstName, evt.PersonName.LastName, evt.PersonName.MiddleName);

				_reportDataAccessor.Commit();

				evt.Result(UserCreatedEvent.Code_USER_ADDED);
			}
			catch (Exception ex)
			{
				evt.Result(UserCreatedEvent.Code_SERVER_ERROR, ex.ToString());
			}
		}
	}
}
