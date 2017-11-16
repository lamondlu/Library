using System;
using System.Threading.Tasks;
using BookLibrary.Domain.Core;
using BookLibrary.Domain.Core.Messaging;
using BookLibrary.Service.Inventory.Domain.DataAccessors;
using BookLibrary.Service.Inventory.Domain.DTOs;
using BookLibrary.Service.Inventory.Domain.Events;

namespace BookLibrary.Service.Inventory.Domain.EventHandlers
{
    public class BookInventoryOutStoredEventHandler : IEventHandler<BookInventoryOutStoredEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;
        private ICommandTracker _commandTracker = null;

        public BookInventoryOutStoredEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker)
        {
            _reportDataAccessor = reportDataAccessor;
            _commandTracker = commandTracker;
        }

        public void Handle(BookInventoryOutStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookInventoryStatus(evt.AggregateId, BookInventoryStatus.OutStore, evt.Notes);
            _reportDataAccessor.Commit();

            _commandTracker.DirectFinish(evt.CommandUniqueId);
        }

        public Task HandleAsync(BookInventoryOutStoredEvent evt)
        {
            return Task.Factory.StartNew(()=>{
                Handle(evt);
            });
        }
    }
}