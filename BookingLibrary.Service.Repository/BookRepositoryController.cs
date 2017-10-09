using System;
using BookingLibrary.Service.Repository.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingLibrary.Service.Repository
{
    [Route("api/bookingRepositories")]
    public class BookRepositoryController : Controller
    {
        [HttpPost]
        public StatusCodeResult CreateBookingRepository(BookViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        public BookViewModel GetBookRepository(Guid id)
        {
            return new BookViewModel
            {
                BookId = Guid.NewGuid(),
                BookName = "Lamond Lu",
                DateIssued = DateTime.Now,
                ISBN = "S001"
            };
        }
    }
}
