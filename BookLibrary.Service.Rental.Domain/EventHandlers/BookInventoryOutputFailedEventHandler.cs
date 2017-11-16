using BookLibrary.Domain.Core;
using BookLibrary.Domain.Core.DataAccessor;
using BookLibrary.Service.Rental.Domain.DataAccessors;
using BookLibrary.Service.Rental.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Domain.Core.Messaging;

namespace BookLibrary.Service.Rental.Domain.EventHandlers
{
    public class BookInventoryOutputFailedEventHandler : IEventHandler<BookInventoryOutputFailedEvent>
    {
        private ICommandTracker _commandTracker = null;

        public BookInventoryOutputFailedEventHandler(ICommandTracker commandTracker)
        {
            _commandTracker = commandTracker;
        }

        public void Handle(BookInventoryOutputFailedEvent evt)
        {
            try
            {
                _commandTracker.DirectError(evt.CommandUniqueId, "Error_BookInventoryOutputFailedEvent", "The book has been output by others, you can't rent this book");
            }
            catch
            {

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