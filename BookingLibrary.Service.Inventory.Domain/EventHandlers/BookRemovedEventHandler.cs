using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Inventory.Domain.DTOs;
using BookingLibrary.Service.Inventory.Domain.Events;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
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