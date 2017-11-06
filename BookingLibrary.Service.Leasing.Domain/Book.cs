using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Leasing.Domain
{
    public class Book : Entity
    {
        public Book()
        {

        }

        public Book(Guid bookId)
        {
            this.Id = bookId;
        }

        public string BookName { get; set; }

        public string ISBN { get; set; }
    }
}
