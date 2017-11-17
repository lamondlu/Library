using System;
using System.Threading.Tasks;
using  Library.Domain.Core;
using  Library.Service.Inventory.Domain.DataAccessors;
using  Library.Service.Inventory.Domain.DTOs;
using  Library.Service.Inventory.Domain.Events;

namespace  Library.Service.Inventory.Domain.EventHandlers
{
    public class BookRemovedEventHandler : IEventHandler<BookRemovedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;

        public BookRemovedEventHandler(IInventoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookRemovedEvent evt)
        {
            
        }

        public Task HandleAsync(BookRemovedEvent evt)
        {
            return null;
        }
    }
}