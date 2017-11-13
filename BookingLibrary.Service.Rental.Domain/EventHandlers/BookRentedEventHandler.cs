using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Rental.Domain.Events;
using BookingLibrary.Service.Rental.Domain.DataAccessors;

namespace BookingLibrary.Service.Rental.Domain
{
    public class BookRentedEventHandler : IEventHandler<BookRentedEvent>
    {
        private IRentalReportDataAccessor _reportDataAccessor = null;

        public BookRentedEventHandler(IRentalReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookRentedEvent evt)
        {
            _reportDataAccessor.RentBook(evt.BookId, evt.BookName, evt.ISBN, evt.AggregateId, evt.Name, evt.RentDate);
            _reportDataAccessor.Commit();
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