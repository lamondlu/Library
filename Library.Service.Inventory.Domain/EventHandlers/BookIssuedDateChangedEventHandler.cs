using Library.Domain.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookIssuedDatehangedEventHandler : IEventHandler<BookIssuedDateChangedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;

        public BookIssuedDatehangedEventHandler(IInventoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookIssuedDateChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookIssuedDate(evt.AggregateId, evt.NewBookIssuedDate);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookIssuedDateChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookIssuedDate(evt.AggregateId, evt.NewBookIssuedDate);
            return _reportDataAccessor.CommitAsync();
        }
    }
}