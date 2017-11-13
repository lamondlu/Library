using System;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.Events;

namespace BookingLibrary.Service.Inventory.Domain
{
    public class BookInventory : Entity
    {
        public BookInventory(Guid id) : base()
        {
            this.Id = id;
        }

        public BookInventoryStatus Status { get; private set; }

        public void InStore()
        {
            this.Status = BookInventoryStatus.InStore;
        }

        public void OutStore()
        {
            this.Status = BookInventoryStatus.OutStore;
        }
    }
}