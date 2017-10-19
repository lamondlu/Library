using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core.Messaging;
using BookingLibrary.Infrastructure.InjectionFramework;
using BookingLibrary.Service.Repository.Application.Commands;
using BookingLibrary.Service.Repository.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingLibrary.Service.Repository
{
    [Route("api/[controller]")]
    public class BookRepositoryController : Controller
    {
        private ICommandPublisher _commandPublisher = null;

        public BookRepositoryController()
        {
            _commandPublisher = InjectContainer.GetInstance<ICommandPublisher>();
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
        public void AddBookRepository(DTOs.BookDTO dto)
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
