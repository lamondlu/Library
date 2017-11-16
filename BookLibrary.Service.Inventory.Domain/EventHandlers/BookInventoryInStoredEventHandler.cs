using System;
using System.Threading.Tasks;
using BookLibrary.Domain.Core;
using BookLibrary.Domain.Core.Messaging;
using BookLibrary.Service.Inventory.Domain.DataAccessors;
using BookLibrary.Service.Inventory.Domain.DTOs;
using BookLibrary.Service.Inventory.Domain.Events;

namespace BookLibrary.Service.Inventory.Domain.EventHandlers
{
    public class BookInventoryInStoredEventHandler : IEventHandler<BookInventoryInStoredEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;
        private ICommandTracker _commandTracker = null;

        public BookInventoryInStoredEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker)
        {
            _reportDataAccessor = reportDataAccessor;
            _commandTracker = commandTracker;
        }

        public void Handle(BookInventoryInStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookInventoryStatus(evt.AggregateId, BookInventoryStatus.InStore, evt.Notes);
            _reportDataAccessor.Commit();

            _commandTracker.DirectFinish(evt.CommandUniqueId);
        }

        public Task HandleAsync(BookInventoryInStoredEvent evt)
        {
            return Task.Factory.StartNew(()=>{
                Handle(evt);
            });
        }
    }
}