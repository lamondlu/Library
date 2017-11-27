using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookDescriptionChangedEventHandler : BaseInventoryEventHandler<BookDescriptionChangedEvent>
    {
        public BookDescriptionChangedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void Handle(BookDescriptionChangedEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookDescription(evt.AggregateId, evt.Description);
                _reportDataAccessor.Commit();

                AddEventLog(evt, "BOOKDESCRIPTION_UPDATED");
            }
            catch (Exception ex)
            {
                AddEventLog(evt, "SERVER_ERROR", ex.ToString());
            }
        }
    }
}