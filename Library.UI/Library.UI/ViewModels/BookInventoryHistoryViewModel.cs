using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.UI.ViewModels
{
    public class BookInventoryHistoryViewModel
    {
        public Guid HistoryId { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}