using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Leasing.Domain.Events;
using BookingLibrary.Service.Leasing.Domain.DataAccessors;

namespace BookingLibrary.Service.Leasing.Domain
{
    public class BookRentedEventHandler : IEventHandler<BookRentedEvent>
    {
        private ILeasingReportDataAccessor _reportDataAccessor = null;

        public BookRentedEventHandler(ILeasingReportDataAccessor reportDataAccessor)
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