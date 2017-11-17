using System;
using  Library.Domain.Core;

namespace  Library.Service.Rental.Domain
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
