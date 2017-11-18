using Library.Domain.Core;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain
{
    public class BookReturnedEventHandler : IEventHandler<BookReturnedEvent>
    {
        private IRentalReportDataAccessor _reportDataAccessor = null;
        private ICommandTracker _commandTracker = null;

        public BookReturnedEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker)
        {
            _reportDataAccessor = reportDataAccessor;
            _commandTracker = commandTracker;
        }

        public void Handle(BookReturnedEvent evt)
        {
            try
            {
                _reportDataAccessor.ReturnBook(evt.BookId, evt.ReturnDate);
                _reportDataAccessor.Commit();

                _commandTracker.DirectFinish(evt.CommandUniqueId);
            }
            catch
            {

            }
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