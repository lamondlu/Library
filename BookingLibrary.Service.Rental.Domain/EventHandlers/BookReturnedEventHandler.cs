using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Rental.Domain.Events;
using BookingLibrary.Service.Rental.Domain.DataAccessors;

namespace BookingLibrary.Service.Rental.Domain
{
    public class BookReturnedEventHandler : IEventHandler<BookReturnedEvent>
    {
        private IRentalReportDataAccessor _reportDataAccessor = null;

        public BookReturnedEventHandler(IRentalReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookReturnedEvent evt)
        {
            _reportDataAccessor.ReturnBook(evt.BookId, evt.ReturnDate);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookReturnedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}