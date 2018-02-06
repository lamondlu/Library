using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;

namespace Library.Service.Identity.Domain
{
	[EventLog(Code = Code_USER_ADDED, Message = "Event Finished.", Type = LogType.Info, SendFinish = true)]
	[EventLog(Code = Code_SERVER_ERROR, Type = LogType.Info, SendError = true)]
	public class UserCreatedEvent : DomainEvent
	{
		public const string Code_USER_ADDED = "USER_ADDED";
		private readonly static string Event_UserCreated = "Event_UserCreated";

		public UserCreatedEvent() : base(Event_UserCreated)
		{
		}

		public UserPrincipal Principal { get; set; }

		public PersonName PersonName { get; set; }
	}
}