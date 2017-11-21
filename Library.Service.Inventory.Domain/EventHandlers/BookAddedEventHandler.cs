using Library.Domain.Core;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.DTOs;
using Library.Service.Inventory.Domain.Events;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookAddedEventHandler : IEventHandler<BookAddedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;
        private ICommandTracker _commandTracker = null;
        private ILogger _logger = null;

        public BookAddedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger)
        {
            _reportDataAccessor = reportDataAccessor;
            _commandTracker = commandTracker;
            _logger = logger;
        }

        public void Handle(BookAddedEvent evt)
        {
            try
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
            catch
            {

            }
        }

        public Task HandleAsync(BookAddedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}