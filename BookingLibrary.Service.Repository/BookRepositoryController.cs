using System;
using System.Collections.Generic;
using BookingLibrary.Service.Repository.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingLibrary.Service.Repository
{
    [Route("api/[controller]")]
    public class BookRepositoryController : Controller
    {
        [HttpPost]
        public StatusCodeResult CreateBookingRepository(BookViewModel model)
        {
            return Ok();
        }

        [HttpGet("")]
        public List<BookViewModel> GetAllBooks()
        {
            return new List<BookViewModel>{
                new BookViewModel
                {
                    BookId = Guid.NewGuid(),
                    BookName = "Lamond Lu",
                    DateIssued = DateTime.Now,
                    ISBN = "S001"
                }
            };
        }

        [HttpGet("{id}")]
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
