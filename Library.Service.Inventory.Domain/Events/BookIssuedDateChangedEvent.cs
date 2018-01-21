using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Events
{
	[EventLog(Code = Code_BOOKISSUEDDATE_CHANGED, Message = "Event finished.", Type = LogType.Info)]
	[EventLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
	public class BookIssuedDateChangedEvent : DomainEvent
	{
		public readonly static string Event_BookIssuedDateChanged = "Event_BookIssuedDateChanged";
		public const string Code_BOOKISSUEDDATE_CHANGED = "BOOKISSUEDDATE_CHANGED";

		public BookIssuedDateChangedEvent() : base(Event_BookIssuedDateChanged)
		{
		}

		public DateTime NewBookIssuedDate { get; set; }

		public Guid BookId { get; set; }
	}
}