using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Leasing.Domain.Events;
using System.Linq;

namespace BookingLibrary.Service.Leasing.Domain
{
    public class Customer : AggregateRoot,
    IHandler<BookRentedEvent>,
    IHandler<BookReturnedEvent>,
    IHandler<CustomerAccountInitializedEvent>
    {
        public Customer()
        {

        }

        public Customer(Guid customerId, PersonName name)
        {
            ApplyChange(new CustomerAccountInitializedEvent
            {
                AggregateId = customerId,
                Name = name
            });
        }

        public PersonName Name { get; set; }

        public List<Book> Books { get; internal set; }

        public void Handle(BookRentedEvent evt)
        {
            this.Books.Add(new Book(evt.BookId)
            {
                BookName = evt.BookName,
                ISBN = evt.ISBN
            });
        }

        public void Handle(BookReturnedEvent evt)
        {
            this.Books.RemoveAll(p => p.Id == evt.BookId);
        }

        public void Handle(CustomerAccountInitializedEvent evt)
        {
            this.Books = new List<Book>();
            this.Name = evt.Name;
            this.Id = evt.AggregateId;
        }

        public void RentBook(Book book)
        {
            if (this.Books.Count > 3)
            {
                throw new Exception("One customer can only rent 3 books at most.");
            }

            ApplyChange(new BookRentedEvent
            {
                ISBN = book.ISBN,
                BookName = book.BookName,
                BookId = book.Id,
                RentDate = DateTime.Now,
                AggregateId = this.Id,
                Name = this.Name
            });
        }

        public void ReturnBook(Guid bookId)
        {
            ApplyChange(new BookReturnedEvent
            {
                BookId = bookId,
                ReturnDate = DateTime.Now
            });
        }
    }
}
