using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Inventory.Domain.DTOs;
using BookingLibrary.Service.Inventory.Domain.Events;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
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