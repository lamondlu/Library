using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core.Messaging;
using BookingLibrary.Infrastructure.InjectionFramework;
using BookingLibrary.Service.Repository.Domain;
using BookingLibrary.Service.Repository.Domain.Commands;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.ViewModels;
using BookingLibrary.Service.Repository.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookingLibrary.Service.Repository
{
    [Route("api/[controller]")]
    public class BookRepositoryController : Controller
    {
        private ICommandPublisher _commandPublisher = null;
        private IRepositoryReportDataAccessor _reportDatabase = null;

        public BookRepositoryController()
        {
            _commandPublisher = InjectContainer.GetInstance<ICommandPublisher>();
            _reportDatabase = InjectContainer.GetInstance<IRepositoryReportDataAccessor>();
        }

        [HttpGet("")]
        public List<BookViewModel> GetAllBooks()
        {
            return _reportDatabase.GetBookRepositories();
        }

        [HttpGet("{id}")]
        public BookDetailedModel GetBookRepository(Guid id)
        {
            return _reportDatabase.GetBookById(id);
        }

        [HttpPut("")]
        public void UpdateBookRepository(DTOs.BookDTO dto)
        {
            _commandPublisher.Publish(new UpdateBookCommand
            {
                BookId = dto.BookId,
                BookName = dto.BookName,
                ISBN = dto.ISBN,
                DateIssued = dto.IssueDate,
                Description = dto.Description
            });
        }

        [HttpPost("")]
        public Guid AddBookRepository(BookDTO dto)
        {
            var command = new AddBookCommand
            {
                BookId = Guid.NewGuid(),
                BookName = dto.BookName,
                ISBN = dto.ISBN,
                DateIssued = dto.IssueDate,
                Description = dto.Description
            };

            _commandPublisher.Publish(command);

            return command.CommandUniqueId;
        }

        [HttpPost("{bookId}/status")]
        public void InStoredBook(Guid bookId, ChangeBookStatusDTO dto)
        {
            if (dto.Status == BookStatus.InStore)
            {
                _commandPublisher.Publish(new InStoreBookCommand
                {
                    BookId = bookId
                });
            }
            else
            {
                _commandPublisher.Publish(new OutStoreBookCommand
                {
                    BookId = bookId
                });
            }
        }
    }
}
