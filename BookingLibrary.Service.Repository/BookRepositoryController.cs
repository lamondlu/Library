using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core.Messaging;
using BookingLibrary.Service.Repository.Application.Commands;
using BookingLibrary.Service.Repository.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingLibrary.Service.Repository
{
    [Route("api/[controller]")]
    public class BookRepositoryController : Controller
    {
        private ICommandPublisher _commandPublisher = null;

        public BookRepositoryController(ICommandPublisher commandPublisher)
        {
            _commandPublisher = commandPublisher;
        }

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

        [HttpPost("")]
        public void AddBook(DTOs.BookDTO dto)
        {
            _commandPublisher.Publish(new AddBookCommand
            {
                BookId = Guid.NewGuid(),
                BookName = dto.BookName,
                ISBN = dto.ISBN,
                DateIssued = dto.IssueDate,
                Description = dto.Description
            });
        }
    }
}
