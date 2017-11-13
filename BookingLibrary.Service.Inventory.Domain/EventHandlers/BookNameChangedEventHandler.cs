using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Inventory.Domain.DTOs;
using BookingLibrary.Service.Inventory.Domain.Events;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
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