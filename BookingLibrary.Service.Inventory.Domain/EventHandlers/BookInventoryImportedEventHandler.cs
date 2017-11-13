using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Inventory.Domain.DTOs;
using BookingLibrary.Service.Inventory.Domain.Events;
using System.Linq;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
{
    public class BookInventoryImportedEventHandler : IEventHandler<BookInventoryImportedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;

        public BookInventoryImportedEventHandler(IInventoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookInventoryImportedEvent evt)
        {
            var bookRepositories = evt.BookInventoryIds.Select(p => new BookInventory(p)).ToList();

            foreach (var item in bookRepositories)
            {
                item.InStore();
            }

            _reportDataAccessor.ImportBookRepositoies(evt.AggregateId, bookRepositories);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookInventoryImportedEvent evt)
        {
            var bookRepositories = evt.BookInventoryIds.Select(p => new BookInventory(p)).ToList();

            foreach (var item in bookRepositories)
            {
                item.InStore();
            }

            _reportDataAccessor.ImportBookRepositoies(evt.AggregateId, bookRepositories);
            return _reportDataAccessor.CommitAsync();
        }
    }
}