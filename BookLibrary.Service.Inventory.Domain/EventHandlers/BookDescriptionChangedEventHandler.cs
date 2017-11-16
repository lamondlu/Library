using System;
using System.Threading.Tasks;
using BookLibrary.Domain.Core;
using BookLibrary.Service.Inventory.Domain.DataAccessors;
using BookLibrary.Service.Inventory.Domain.DTOs;
using BookLibrary.Service.Inventory.Domain.Events;

namespace BookLibrary.Service.Inventory.Domain.EventHandlers
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