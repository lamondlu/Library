using Library.Domain.Core;
using System;

namespace Library.Service.Inventory.Domain.Events
{
	public class RentBookRequestSucceedEvent : DomainEvent
	{
		private static string Event_RentBookRequestSucceed = "Event_RentBookRequestSucceed";

		public RentBookRequestSucceedEvent() : base(Event_RentBookRequestSucceed)
		{
		}

		public Guid BookInventoryId { get; set; }

		public Guid CustomerId { get; set; }
	}
}