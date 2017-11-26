using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookInventoryOutStoredEventHandler : BaseEventHandler<BookInventoryOutStoredEvent>
    {

        public BookInventoryOutStoredEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {

        }

        public override void Handle(BookInventoryOutStoredEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookInventoryStatus(evt.AggregateId, BookInventoryStatus.OutStore, evt.Notes);
                _reportDataAccessor.Commit();

                _commandTracker.DirectFinish(evt.CommandUniqueId);
                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
            }
        }
    }
}