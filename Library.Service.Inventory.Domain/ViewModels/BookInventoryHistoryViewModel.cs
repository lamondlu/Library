using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service.Inventory.Domain.ViewModels
{
    public class BookInventoryHistoryViewModel
    {
        public Guid HistoryId { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
