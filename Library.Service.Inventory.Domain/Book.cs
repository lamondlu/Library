using Library.Domain.Core;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain
{
    public class Book : AggregateRoot,
    IHandler<BookAddedEvent>,
    IHandler<BookRemovedEvent>,
    IHandler<BookISBNChangedEvent>,
    IHandler<BookNameChangedEvent>,
    IHandler<BookIssuedDateChangedEvent>,
    IHandler<BookDescriptionChangedEvent>
    {
        public Book()
        {
        }

        public Book(Guid bookId, string isbn, string bookName, string description, DateTime dateIssued)
        {
            ApplyChange(new BookAddedEvent
            {
                ISBN = isbn,
                BookName = bookName,
                DateIssued = dateIssued,
                AggregateId = bookId,
                Description = description
            });
        }

        public string ISBN { get; internal set; }

        public string BookName { get; internal set; }

        public string Description { get; internal set; }

        public DateTime DateIssued { get; internal set; }

        public void ChangeBookName(string bookName)
        {
            ApplyChange(new BookNameChangedEvent
            {
                BookId = Id,
                NewBookName = bookName
            });
        }

        public void ChangeDescription(string description)
        {
            ApplyChange(new BookDescriptionChangedEvent
            {
                AggregateId = Id,
                Description = description
            });
        }

        public void ChangeISBN(string isbn)
        {
            ApplyChange(new BookISBNChangedEvent
            {
                AggregateId = Id,
                NewBookISBN = isbn
            });
        }

        public void ChangeIssuedDate(DateTime issuedDate)
        {
            ApplyChange(new BookIssuedDateChangedEvent
            {
                AggregateId = Id,
                NewBookIssuedDate = issuedDate
            });
        }

        public void Handle(BookAddedEvent evt)
        {
            this.BookName = evt.BookName;
            this.DateIssued = evt.DateIssued;
            this.Id = evt.AggregateId;
            this.ISBN = evt.ISBN;
            this.Description = evt.Description;
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

        public void Handle(BookDescriptionChangedEvent evt)
        {
            this.Description = evt.Description;
        }
    }
}