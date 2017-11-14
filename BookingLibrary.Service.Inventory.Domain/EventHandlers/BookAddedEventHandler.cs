using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.Messaging;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Inventory.Domain.DTOs;
using BookingLibrary.Service.Inventory.Domain.Events;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
{
    public class BookAddedEventHandler : IEventHandler<BookAddedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;
        private ICommandTracker _commandTracker = null;

        public BookAddedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker _commandTracker)
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
            _commandTracker.DirectFinish(evt.CommandUniqueId);
            
        }

        public Task HandleAsync(BookAddedEvent evt)
        {
            return Task.Factory.StartNew(()=>{
                Handle(evt);
            });
        }
    }
}