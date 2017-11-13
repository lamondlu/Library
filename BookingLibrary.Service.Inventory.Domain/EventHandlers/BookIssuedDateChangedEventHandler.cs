using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Inventory.Domain.DTOs;
using BookingLibrary.Service.Inventory.Domain.Events;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
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