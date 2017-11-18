using Library.Domain.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookDescriptionChangedEventHandler : IEventHandler<BookDescriptionChangedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;

        public BookDescriptionChangedEventHandler(IInventoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookDescriptionChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookDescription(evt.AggregateId, evt.Description);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookDescriptionChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookDescription(evt.AggregateId, evt.Description);
            return _reportDataAccessor.CommitAsync();
        }
    }
}