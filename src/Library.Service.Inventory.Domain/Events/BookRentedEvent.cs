using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;
using System;

namespace Library.Service.Inventory.Domain.Events
{
	public class BookRentedEvent : DomainEvent
	{
		public readonly static string Event_BookRented = "Event_BookRented";

		public BookRentedEvent() : base(Event_BookRented)
		{
		}

		public Guid BookInventoryId { get; set; }

        public Guid CustomerId { get; set; }
	}
}