using System;
using System.Threading.Tasks;
using BookLibrary.Domain.Core;
using BookLibrary.Service.Rental.Domain.Events;
using BookLibrary.Service.Rental.Domain.DataAccessors;

namespace BookLibrary.Service.Rental.Domain
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