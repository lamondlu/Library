using System;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.Events;

namespace BookingLibrary.Service.Inventory.Domain
{
    public class BookInventory : AggregateRoot,
        IHandler<BookInventoryInStoredEvent>,
        IHandler<BookInventoryOutStoredEvent>,
        IHandler<BookInventoryCreatedEvent>
    {
        public BookInventory()
        {

        }

        public BookInventory(Guid bookInventoryId, Guid bookId, string notes)
        {
            ApplyChange(new BookInventoryCreatedEvent
            {
                AggregateId = bookInventoryId,
                BookId = bookId,
                Notes = notes
            });
        }

        public Guid BookId { get; internal set; }

        public BookInventoryStatus Status { get; internal set; }

        public void Handle(BookInventoryInStoredEvent evt)
        {
            this.Status = BookInventoryStatus.InStore;
        }

        public void Handle(BookInventoryOutStoredEvent evt)
        {
            this.Status = BookInventoryStatus.OutStore;
        }

        public void Handle(BookInventoryCreatedEvent evt)
        {
            this.BookId = evt.BookId;
            this.Id = evt.AggregateId;
            this.Status = BookInventoryStatus.InStore;
        }

        public void InStore(string notes)
        {
            if (this.Status == BookInventoryStatus.InStore)
            {
                throw new Exception("The book is still in store.");
            }

            ApplyChange(new BookInventoryInStoredEvent
            {
                Notes = notes,
                AggregateId = this.Id
            });
        }

        public void OutStore(string notes)
        {
            if (this.Status == BookInventoryStatus.OutStore)
            {
                throw new Exception("The book is still out store.");
            }

            ApplyChange(new BookInventoryOutStoredEvent
            {
                Notes = notes,
                AggregateId = this.Id
            });
        }
    }
}