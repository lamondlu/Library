using System;

namespace BookingLibrary.Service.Repository.Domain.ViewModels
{
    public class BookViewModel
    {
        public Guid BookId { get; set; }

        public string ISBN { get; set; }

        public string BookName { get; set; }

        public BookStatus BookStatus { get; set; }

        public DateTime DateIssued { get; set; }
    }
}
