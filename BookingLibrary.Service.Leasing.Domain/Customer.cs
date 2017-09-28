using System;
using System.Collections.Generic;

namespace BookingLibrary.Service.Leasing.Domain
{
    public class Customer
    {
        public Customer()
        {

        }

        public Guid CustomerId
        {
            get;
            internal set;
        }

        public List<Book> Books
        {
            get;
            internal set;
        }

        public void RentBook(Book book)
        {
            
        }

        public void ReturnBook(Book book)
        {

        }
    }
}
