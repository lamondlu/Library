using System;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain
{
    public class Book : AggregateRoot, 
    IHandler<BookAddedEvent>, 
    IHandler<BookRemovedEvent>, 
    IHandler<BookISBNChangedEvent>, 
    IHandler<BookNameChangedEvent>, 
    IHandler<BookIssuedDateChangedEvent>
    {
        public Book()
        {

        }

        public Book(Guid bookId, string isbn, string bookName, DateTime dateIssued)
        {
            ApplyChange(new BookAddedEvent
            {
                ISBN = isbn,
                BookName = bookName,
                DateIssued = dateIssued,
                AggregateId = bookId
            });
        }

        public string ISBN { get; internal set; }

        public string BookName { get; internal set; }

        public DateTime DateIssued { get; internal set; }

        public void ChangeBookName(string bookName)
        {
            ApplyChange(new BookNameChangedEvent
            {
                BookId = Id,
                NewBookName = bookName
            });
        }

        public void ChangeISBN(string isbn)
        {
            ApplyChange(new BookISBNChangedEvent
            {
                BookId = Id,
                NewBookISBN = isbn
            });
        }

        public void ChangeIssuedDate(DateTime issuedDate)
        {
            ApplyChange(new BookIssuedDateChangedEvent
            {
                BookId = Id,
                NewBookIssuedDate = issuedDate
            });
        }

        public void Handle(BookAddedEvent evt)
        {
            this.BookName = evt.BookName;
            this.DateIssued = evt.DateIssued;
            this.Id = evt.AggregateId;
            this.ISBN = evt.ISBN;
        }

        public void Handle(BookRemovedEvent evt)
        {

        }

        public void Handle(BookIssuedDateChangedEvent evt)
        {
            this.DateIssued = evt.NewBookIssuedDate;
        }

        public void Handle(BookNameChangedEvent evt)
        {
            this.BookName = evt.NewBookName;
        }

        public void Handle(BookISBNChangedEvent evt)
        {
            this.ISBN = evt.NewBookISBN;
        }

        public void Remove()
        {
            ApplyChange(new BookRemovedEvent());
        }
    }
}
