using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Inventory.Domain.DTOs;
using BookingLibrary.Service.Inventory.Domain.Events;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
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