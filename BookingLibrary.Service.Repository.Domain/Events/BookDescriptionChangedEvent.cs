using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.Events
{
    public class BookDescriptionChangedEvent : DomainEvent
    {
        public string Description { get; set; }
    }
}