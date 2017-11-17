using System;
using System.Threading.Tasks;
using  Library.Domain.Core;
using  Library.Domain.Core.Messaging;
using  Library.Service.Inventory.Domain.DataAccessors;
using  Library.Service.Inventory.Domain.DTOs;
using  Library.Service.Inventory.Domain.Events;

namespace  Library.Service.Inventory.Domain.EventHandlers
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