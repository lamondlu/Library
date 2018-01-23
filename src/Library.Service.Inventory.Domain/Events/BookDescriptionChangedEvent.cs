using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;

namespace Library.Service.Inventory.Domain.Events
{
	[EventLog(Code = Code_BOOKDESCRIPTION_UPDATED, Message = "Event Finished.", Type = LogType.Info)]
	[EventLog(Code = Code_SERVER_ERROR, Type = LogType.Error)]
	public class BookDescriptionChangedEvent : DomainEvent
	{
		public readonly static string Event_BookDescriptionChanged = "Event_BookDescriptionChanged";
		public const string Code_BOOKDESCRIPTION_UPDATED = "BOOKDESCRIPTION_UPDATED";

		public BookDescriptionChangedEvent() : base(Event_BookDescriptionChanged)
		{
		}

		public string Description { get; set; }
	}
}