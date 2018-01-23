using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;

namespace Library.Service.Inventory.Domain.Events
{
	[EventLog(Code = Code_BOOK_REMOVED, Message = "Event finished.", Type = LogType.Info)]
	public class BookRemovedEvent : DomainEvent
	{
		public readonly static string Event_BookRemoved = "Event_BookRemoved";
		public const string Code_BOOK_REMOVED = "BOOK_REMOVED";

		public BookRemovedEvent() : base(Event_BookRemoved)
		{
		}
	}
}