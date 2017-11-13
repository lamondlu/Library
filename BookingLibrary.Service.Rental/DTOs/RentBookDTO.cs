using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Rental.DTOs
{
    public class RentBookDTO
    {
        public Guid BookId { get; set; }

        public PersonName Name { get; set; }

        public string BookName { get; set; }

        public string ISBN { get; set; }

        public Guid CustomerId { get; set; }
    }
}