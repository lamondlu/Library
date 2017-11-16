using System;
using System.Threading.Tasks;
using BookLibrary.Domain.Core;
using BookLibrary.Service.Inventory.Domain.DataAccessors;
using BookLibrary.Service.Inventory.Domain.DTOs;
using BookLibrary.Service.Inventory.Domain.Events;

namespace BookLibrary.Service.Inventory.Domain.EventHandlers
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