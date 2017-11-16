using System;
using System.Threading.Tasks;
using BookLibrary.Domain.Core;
using BookLibrary.Domain.Core.Messaging;
using BookLibrary.Service.Inventory.Domain.DataAccessors;
using BookLibrary.Service.Inventory.Domain.DTOs;
using BookLibrary.Service.Inventory.Domain.Events;

namespace BookLibrary.Service.Inventory.Domain.EventHandlers
{
    public class BookAddedEventHandler : IEventHandler<BookAddedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;
        private ICommandTracker _commandTracker = null;

        public BookAddedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker)
        {
            _reportDataAccessor = reportDataAccessor;
            _commandTracker = commandTracker;
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