using Library.Domain.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookISBNChangedEventHandler : IEventHandler<BookISBNChangedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;

        public BookISBNChangedEventHandler(IInventoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookISBNChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookISBN(evt.AggregateId, evt.NewBookISBN);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookISBNChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookISBN(evt.AggregateId, evt.NewBookISBN);
            return _reportDataAccessor.CommitAsync();
        }
    }
}