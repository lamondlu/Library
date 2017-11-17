using System;
using System.Threading.Tasks;
using  Library.Domain.Core;
using  Library.Service.Inventory.Domain.DataAccessors;
using  Library.Service.Inventory.Domain.DTOs;
using  Library.Service.Inventory.Domain.Events;

namespace  Library.Service.Inventory.Domain.EventHandlers
{
    public class BookNameChangedEventHandler : IEventHandler<BookNameChangedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;

        public BookNameChangedEventHandler(IInventoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookNameChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookName(evt.AggregateId, evt.NewBookName);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookNameChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookName(evt.AggregateId, evt.NewBookName);
            return _reportDataAccessor.CommitAsync();
        }
    }
}