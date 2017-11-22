using Library.Domain.Core;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public class BookInventoryOutputFailedEventHandler : IEventHandler<BookInventoryOutputFailedEvent>
    {
        private ICommandTracker _commandTracker = null;
        private ILogger _logger = null;

        public BookInventoryOutputFailedEventHandler(ICommandTracker commandTracker, ILogger logger)
        {
            _commandTracker = commandTracker;
            _logger = logger;
        }

        public void Handle(BookInventoryOutputFailedEvent evt)
        {
            try
            {
                _commandTracker.DirectError(evt.CommandUniqueId, "Error_BookInventoryOutputFailedEvent", "The book has been output by others, you can't rent this book");

                _logger.EventWarning(evt, "The book has been output by others, you can't rent this book");
            }
            catch (Exception ex)
            {
                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
            }
        }

        public Task HandleAsync(BookInventoryOutputFailedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}