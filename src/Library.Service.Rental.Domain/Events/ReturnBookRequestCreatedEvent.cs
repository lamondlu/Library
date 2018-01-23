using Library.Domain.Core;
using System;

namespace Library.Service.Rental.Domain.Events
{
	public class ReturnBookRequestCreatedEvent : DomainEvent
	{
		private static string Event_ReturnBookRequestCreated = "Event_ReturnBookRequestCreated";

		public ReturnBookRequestCreatedEvent() : base(Event_ReturnBookRequestCreated)
		{
		}

		public Guid BookInventoryId { get; set; }

		public DateTime ReturnDate { get; set; }

		public PersonName Name { get; set; }
	}
}