using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Inventory.Domain.DTOs;
using BookingLibrary.Service.Inventory.Domain.Events;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
{
    public class BookAddedEventHandler : IEventHandler<BookAddedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;

        public BookAddedEventHandler(IInventoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookAddedEvent evt)
        {
            _reportDataAccessor.AddBook(new AddBookDTO
            {
                BookId = evt.AggregateId,
                BookName = evt.BookName,
                Description = evt.Description,
                ISBN = evt.ISBN,
                DateIssued = evt.DateIssued
            });

            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookAddedEvent evt)
        {
            _reportDataAccessor.AddBook(new AddBookDTO
            {
                BookId = evt.AggregateId,
                BookName = evt.BookName,
                Description = evt.Description,
                ISBN = evt.ISBN,
                DateIssued = evt.DateIssued
            });

            return _reportDataAccessor.CommitAsync();
        }
    }
}