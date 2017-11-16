using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingLibrary.UI
{
    public class BookViewModel
    {
        public Guid BookId { get; set; }

        public string ISBN { get; set; }

        public string BookName { get; set; }

        public string Description { get; set; }

        public DateTime DateIssued { get; set; }
    }
}