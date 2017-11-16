using System;
using System.Threading.Tasks;
using BookLibrary.Domain.Core;
using BookLibrary.Service.Inventory.Domain.DataAccessors;
using BookLibrary.Service.Inventory.Domain.DTOs;
using BookLibrary.Service.Inventory.Domain.Events;

namespace BookLibrary.Service.Inventory.Domain.EventHandlers
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