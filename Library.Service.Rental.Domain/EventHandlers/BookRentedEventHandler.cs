using  Library.Domain.Core;
using  Library.Domain.Core.Messaging;
using  Library.Service.Rental.Domain.DataAccessors;
using  Library.Service.Rental.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace  Library.Service.Rental.Domain.EventHandlers
{
    public class BookRentedEventHandler : IEventHandler<BookRentedEvent>
    {
        private IRentalReportDataAccessor _dataAccessor = null;
        private ICommandTracker _commandTracker = null;

        public BookRentedEventHandler(IRentalReportDataAccessor dataAccessor, ICommandTracker commandTracker)
        {
            _dataAccessor = dataAccessor;
            _commandTracker = commandTracker;
        }

        public void Handle(BookRentedEvent evt)
        {
            try
            {
                _dataAccessor.RentBook(evt.BookInventoryId);
                _dataAccessor.Commit();

                _commandTracker.DirectFinish(evt.CommandUniqueId);
            }
            catch
            {

            }
        }

        public Task HandleAsync(BookRentedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}
