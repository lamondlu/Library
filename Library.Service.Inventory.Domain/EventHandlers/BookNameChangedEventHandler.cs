using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookNameChangedEventHandler : BaseInventoryEventHandler<BookNameChangedEvent>
    {
        public BookNameChangedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void Handle(BookNameChangedEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookName(evt.AggregateId, evt.NewBookName);
                _reportDataAccessor.Commit();

                AddEventLog(evt, "BOOKNAME_CHANGED");
            }
            catch (Exception ex)
            {
                AddEventLog(evt, "SERVER_ERROR", ex.ToString());
            }
        }
    }
}