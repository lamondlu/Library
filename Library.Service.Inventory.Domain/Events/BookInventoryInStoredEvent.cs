using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Events
{
	[EventLog(Code = Code_BOOKINVENTORY_INSTORED, SendFinish = true, Message = "Event Finished.", Type = LogType.Info)]
	[EventLog(Code = Code_SERVER_ERROR, Message = "Event Finished.", Type = LogType.Error)]
	public class BookInventoryInStoredEvent : DomainEvent
	{
		public readonly static string Event_BookInventoryInStored = "Event_BookInventoryInStored";
		public const string Code_BOOKINVENTORY_INSTORED = "BOOKINVENTORY_INSTORED";

		public BookInventoryInStoredEvent() : base(Event_BookInventoryInStored)
		{
		}

		public string Notes { get; set; }

		public DateTime InStoreDate { get; set; }
	}
}