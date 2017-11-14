using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Service.Inventory.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookingLibrary.Service.Inventory.Domain.EventHandlers
{
    public class RentedBookOutStoredEventHandler : IEventHandler<RentedBookOutStoredEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;

        public RentedBookOutStoredEventHandler(IInventoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(RentedBookOutStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookInventoryStatus(evt.AggregateId, BookInventoryStatus.OutStore, evt.Notes);
            _reportDataAccessor.Commit();


        }

        public Task HandleAsync(RentedBookOutStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookInventoryStatus(evt.AggregateId, BookInventoryStatus.OutStore, evt.Notes);
            return _reportDataAccessor.CommitAsync();
        }
    }
}
