using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Domain.Core.Models;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookInventoryInStoredEventHandler : BaseInventoryEventHandler<BookInventoryInStoredEvent>
    {
        public BookInventoryInStoredEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {

        }

        
        public override void Handle(BookInventoryInStoredEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookInventoryStatus(evt.AggregateId, BookInventoryStatus.InStore, evt.Notes);
                _reportDataAccessor.Commit();

                AddEventLogAndSendToTracker(evt, "BOOKINVENTORY_INSTORED");
            }
            catch (Exception ex)
            {
                AddEventLog(evt, "SERVER_ERROR", ex.ToString());
            }
        }
    }
}