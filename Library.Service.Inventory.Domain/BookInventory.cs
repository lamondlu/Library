using Library.Domain.Core;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain
{
	public class BookInventory : AggregateRoot,
		IHandler<BookInventoryInStoredEvent>,
		IHandler<BookInventoryOutStoredEvent>,
		IHandler<BookInventoryCreatedEvent>,
		IHandler<RentedBookOutStoredEvent>
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

		public void Handle(RentedBookOutStoredEvent evt)
		{
			this.Status = BookInventoryStatus.OutStore;
		}

		public void InStore(string notes, DateTime inStoreDate)
		{
			if (this.Status == BookInventoryStatus.InStore)
			{
				throw new Exception("The book is still in store.");
			}

			ApplyChange(new BookInventoryInStoredEvent
			{
				Notes = notes,
				AggregateId = this.Id,
				InStoreDate = inStoreDate
			});
		}

		public void OutStore(string notes, DateTime outStoreDate)
		{
			if (this.Status == BookInventoryStatus.OutStore)
			{
				throw new Exception("The book is still out store.");
			}

			ApplyChange(new BookInventoryOutStoredEvent
			{
				Notes = notes,
				AggregateId = this.Id,
				OutStoreDate = outStoreDate
			});
		}

		public void RentedBookOutStore(Guid customerId, string notes)
		{
			if (this.Status == BookInventoryStatus.OutStore)
			{
				throw new Exception("The book is still out store.");
			}

			ApplyChange(new RentedBookOutStoredEvent
			{
				Notes = notes,
				AggregateId = this.Id,
				CustomerId = customerId
			});
		}
	}
}