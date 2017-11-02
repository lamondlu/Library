using System;

namespace BookingLibrary.Service.Repository.Domain.ViewModels
{
    public class BookDetailedModel
    {
        public Guid BookId { get; set; }

        public string ISBN { get; set; }

        public string BookName { get; set; }

        public string Description { get; set; }

        public DateTime DateIssued { get; set; }
    }
}
