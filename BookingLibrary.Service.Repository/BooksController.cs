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
    public class BooksController : Controller
    {
        private ICommandPublisher _commandPublisher = null;
        private IRepositoryReportDataAccessor _reportDatabase = null;

        public BooksController()
        {
            _commandPublisher = InjectContainer.GetInstance<ICommandPublisher>();
            _reportDatabase = InjectContainer.GetInstance<IRepositoryReportDataAccessor>();
        }

        [HttpGet("")]
        public List<BookViewModel> GetAllBooks()
        {
            return _reportDatabase.GetBooks();
        }

        [HttpGet("{id}")]
        public BookDetailedModel GetBook(Guid id)
        {
            return _reportDatabase.GetBookById(id);
        }

        [HttpPut("{id}")]
        public Guid UpdateBook(Guid id, DTOs.BookDTO dto)
        {
            var command = new UpdateBookCommand
            {
                BookId = dto.BookId,
                BookName = dto.BookName,
                ISBN = dto.ISBN,
                DateIssued = dto.IssueDate,
                Description = dto.Description
            };

            _commandPublisher.Publish(command);
            return command.CommandUniqueId;
        }

        [HttpPost("")]
        public Guid AddBook(BookDTO dto)
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

        [HttpGet("~/api/available_books")]
        public List<AvailableBookLookupModel> GetAllAvailableBooks()
        {
            return _reportDatabase.GetAvailableBooks();
        }

        [HttpPost("{bookId}/repositories")]
        public Guid ImportBookRepository(Guid bookId, [FromBody]ImportBookRepositoryDTO dto)
        {
            var command = new ImportBookRepositoryCommand
            {
                BookRepositoryIds = dto.BookRepositoryIds,
                BookId = bookId
            };

            _commandPublisher.Publish(command);
            return command.CommandUniqueId;
        }

        [HttpPut("{bookId}/repositories/{repositoryId}/status")]
        public void ChangeBookRepositoryStatus(Guid bookId, Guid repositoryId, ChangeBookStatusDTO dto)
        {
            if (dto.Status == BookRepositoryStatus.InStore)
            {
                _commandPublisher.Publish(new InStoreBookRepositoryCommand
                {
                    BookId = bookId,
                    BookRepositoryId = repositoryId,
                    Notes = dto.Notes
                });
            }
            else
            {
                _commandPublisher.Publish(new OutStoreBookRepositoryCommand
                {
                    BookId = bookId,
                    BookRepositoryId = repositoryId,
                    Notes = dto.Notes
                });
            }
        }
    }
}
