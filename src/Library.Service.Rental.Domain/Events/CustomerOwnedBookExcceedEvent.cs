using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;

namespace Library.Service.Rental.Domain.Events
{
	[EventLog(Code = "CUSTOMEOWNEDBOOK_EXCCEED", Message = "One customer can only have 3 books at most.", Type = LogType.Warning)]
	[EventLog(Code = "SERVER_ERROR", Type = LogType.Error)]
	public class CustomerOwnedBookExcceedEvent : DomainEvent
	{
		private static string EVENT_CustomerOwnedBookExcceed = "Event_CustomerOwnedBookExcceed";
		public const string Code_CUSTOMEOWNEDBOOK_EXCCEED = "CUSTOMEOWNEDBOOK_EXCCEED";

		public CustomerOwnedBookExcceedEvent() : base(EVENT_CustomerOwnedBookExcceed)
		{
		}
	}
}