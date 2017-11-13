using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.Events;
using System.Linq;

namespace BookingLibrary.Service.Inventory.Domain
{
    public class Book : AggregateRoot,
    IHandler<BookAddedEvent>,
    IHandler<BookRemovedEvent>,
    IHandler<BookISBNChangedEvent>,
    IHandler<BookNameChangedEvent>,
    IHandler<BookIssuedDateChangedEvent>,
    IHandler<BookDescriptionChangedEvent>,
    IHandler<BookInventoryInStoredEvent>,
    IHandler<BookInventoryOutStoredEvent>,
    IHandler<BookInventoryImportedEvent>
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

        public List<BookInventory> BookRepositories { get; set; }

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

        public void OutStoreBookInventory(Guid bookInventoryId, string notes)
        {
            var bookInventory = this.BookRepositories.FirstOrDefault(p => p.Id == bookInventoryId);

            if (bookInventory == null)
            {
                throw new Exception("The book Inventory is not existed.");
            }
            else if (bookInventory.Status == BookInventoryStatus.InStore)
            {
                throw new Exception("The book is still out store.");
            }
            else
            {
                ApplyChange(new BookInventoryOutStoredEvent
                {
                    Notes = notes,
                    BookInventoryId = bookInventory.Id,
                    AggregateId = this.Id
                });
            }
        }

        public void InStoreBookInventory(Guid bookInventoryId, string notes)
        {
            var bookInventory = this.BookRepositories.FirstOrDefault(p => p.Id == bookInventoryId);

            if (bookInventory == null)
            {
                throw new Exception("The book Inventory is not existed.");
            }
            else if (bookInventory.Status == BookInventoryStatus.InStore)
            {
                throw new Exception("The book is still in store.");
            }
            else
            {
                ApplyChange(new BookInventoryInStoredEvent
                {
                    Notes = notes,
                    BookInventoryId = bookInventory.Id,
                    AggregateId = this.Id
                });
            }
        }

        public void Import(List<Guid> InventoryIds)
        {
            ApplyChange(new BookInventoryImportedEvent
            {
                AggregateId = Id,
                BookInventoryIds = InventoryIds
            });
        }

        public void Handle(BookAddedEvent evt)
        {
            this.BookName = evt.BookName;
            this.DateIssued = evt.DateIssued;
            this.Id = evt.AggregateId;
            this.ISBN = evt.ISBN;
            this.Description = evt.Description;
            this.BookRepositories = new List<BookInventory>();
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

        public void Handle(BookInventoryOutStoredEvent evt)
        {
            var Inventory = this.BookRepositories.First(p => p.Id == evt.BookInventoryId);
            Inventory.OutStore();
        }

        public void Handle(BookInventoryInStoredEvent evt)
        {
            var Inventory = this.BookRepositories.First(p => p.Id == evt.BookInventoryId);
            Inventory.InStore();
        }

        public void Handle(BookInventoryImportedEvent evt)
        {
            foreach (var id in evt.BookInventoryIds)
            {
                var bookInventory = new BookInventory(id);

                bookInventory.InStore();
                this.BookRepositories.Add(bookInventory);
            }
        }
    }
}
