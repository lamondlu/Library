using System;
using System.Collections.Generic;

namespace BookingLibrary.Service.Repository.Domain.ViewModels
{
    public class BookDetailedModel
    {
        public BookDetailedModel()
        {
            BookRepositories = new List<BookRepositoryViewModel>();
        }

        public Guid BookId { get; set; }

        public string ISBN { get; set; }

        public string BookName { get; set; }

        public string Description { get; set; }

        public DateTime DateIssued { get; set; }

        public List<BookRepositoryViewModel> BookRepositories { get; set; }
    }

    public class BookRepositoryViewModel
    {
        public Guid BookRepositoryId { get; set; }

        public BookRepositoryStatus Status { get; set; }

        public string LastNote { get; set; }
    }
}
