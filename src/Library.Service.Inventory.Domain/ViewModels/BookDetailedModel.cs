using System;
using System.Collections.Generic;

namespace Library.Service.Inventory.Domain.ViewModels
{
    public class BookDetailedModel
    {
        public BookDetailedModel()
        {
            BookInventories = new List<BookInventoryViewModel>();
        }

        public Guid BookId { get; set; }

        public string ISBN { get; set; }

        public string BookName { get; set; }

        public string Description { get; set; }

        public DateTime DateIssued { get; set; }

        public List<BookInventoryViewModel> BookInventories { get; set; }
    }

    public class BookInventoryViewModel
    {
        public Guid BookInventoryId { get; set; }

        public BookInventoryStatus Status { get; set; }

        public string LastNote { get; set; }
    }
}