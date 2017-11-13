using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Inventory.Domain.DTOs;
using BookingLibrary.Service.Inventory.Domain.Events;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
{
    public class BookInventoryInStoredEventHandler : IEventHandler<BookInventoryInStoredEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;

        public BookInventoryInStoredEventHandler(IInventoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookInventoryInStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookInventoryStatus(evt.AggregateId, BookInventoryStatus.InStore, evt.Notes);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookInventoryInStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookInventoryStatus(evt.AggregateId, BookInventoryStatus.InStore, evt.Notes);
            return _reportDataAccessor.CommitAsync();
        }
    }
}