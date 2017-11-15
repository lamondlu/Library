using BookingLibrary.Domain.Core;
using BookingLibrary.Domain.Core.Messaging;
using BookingLibrary.Service.Rental.Domain.DataAccessors;
using BookingLibrary.Service.Rental.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Service.Rental.Domain.EventHandlers
{
    public class BookRentedEventHandler : IEventHandler<BookRentedEvent>
    {
        private IRentalReportDataAccessor _dataAccessor = null;
        private ICommandTracker _commandTracker = null;

        public BookRentedEventHandler(IRentalReportDataAccessor dataAccessor, ICommandTracker commandTracker)
        {
            _dataAccessor = dataAccessor;
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
