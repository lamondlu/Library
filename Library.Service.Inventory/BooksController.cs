using Library.Domain.Core.Messaging;
using Library.Infrastructure.InjectionFramework;
using Library.Service.Inventory.Domain;
using Library.Service.Inventory.Domain.Commands;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.ViewModels;
using Library.Service.Inventory.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Library.Service.Inventory
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private ICommandPublisher _commandPublisher = null;
        private IInventoryReportDataAccessor _reportDatabase = null;

        public BooksController()
        {
            _commandPublisher = InjectContainer.GetInstance<ICommandPublisher>();
            _reportDatabase = InjectContainer.GetInstance<IInventoryReportDataAccessor>();
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

        [HttpPost("{bookId}/inventories")]
        public Guid ImportBookInventory(Guid bookId, [FromBody]ImportBookInventoryDTO dto)
        {
            var command = new ImportBookInventoryCommand
            {
                BookInventoryIds = dto.BookInventoryIds,
                BookId = bookId
            };

            _commandPublisher.Publish(command);
            return command.CommandUniqueId;
        }

        [HttpGet("~/api/inventories/{bookInventoryId}/histories")]
        public List<BookInventoryHistoryViewModel> GetBookInventoryHistories(Guid bookInventoryId)
        {
            return _reportDatabase.GetBookInventoryHistories(bookInventoryId);
        }

        [HttpPut("{bookId}/inventories/{InventoryId}/status")]
        public void ChangeBookInventoryStatus(Guid bookId, Guid InventoryId, ChangeBookStatusDTO dto)
        {
            if (dto.Status == BookInventoryStatus.InStore)
            {
                _commandPublisher.Publish(new InStoreBookInventoryCommand
                {
                    BookInventoryId = InventoryId,
                    Notes = dto.Notes
                });
            }
            else
            {
                _commandPublisher.Publish(new OutStoreBookInventoryCommand
                {
                    BookInventoryId = InventoryId,
                    Notes = dto.Notes
                });
            }
        }
    }
}