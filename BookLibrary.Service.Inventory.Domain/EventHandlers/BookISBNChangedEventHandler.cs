using System;
using System.Threading.Tasks;
using BookLibrary.Domain.Core;
using BookLibrary.Service.Inventory.Domain.DataAccessors;
using BookLibrary.Service.Inventory.Domain.DTOs;
using BookLibrary.Service.Inventory.Domain.Events;

namespace BookLibrary.Service.Inventory.Domain.EventHandlers
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