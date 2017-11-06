using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Leasing.Domain.Events;
using BookingLibrary.Service.Repository.Domain.DataAccessors;

namespace BookingLibrary.Service.Leasing.Domain
{
    public class BookReturnedEventHandler : IEventHandler<BookReturnedEvent>
    {
        private ILeasingReportDataAccessor _reportDataAccessor = null;

        public BookReturnedEventHandler(ILeasingReportDataAccessor reportDataAccessor)
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