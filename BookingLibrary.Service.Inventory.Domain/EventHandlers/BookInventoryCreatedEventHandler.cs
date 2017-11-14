using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Inventory.Domain.DTOs;
using BookingLibrary.Service.Inventory.Domain.Events;
using System.Linq;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
{
    public class BookInventoryCreatedEventHandler : IEventHandler<BookInventoryCreatedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;

        public BookInventoryCreatedEventHandler(IInventoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookInventoryCreatedEvent evt)
        {
            _reportDataAccessor.AddBookInventory(evt.BookId, evt.AggregateId, BookInventoryStatus.InStore, evt.Notes);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookInventoryCreatedEvent evt)
        {
            _reportDataAccessor.AddBookInventory(evt.BookId, evt.AggregateId, BookInventoryStatus.InStore, evt.Notes);
            return _reportDataAccessor.CommitAsync();
        }
    }
}