using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookAddedEvent : DomainEvent
    {
        public string ISBN { get; set; }

        public string BookName { get; set; }

        public DateTime DateIssued { get; set; }
    }
}
