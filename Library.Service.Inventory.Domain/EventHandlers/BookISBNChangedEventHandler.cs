using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookISBNChangedEventHandler : BaseInventoryEventHandler<BookISBNChangedEvent>
    {
        public BookISBNChangedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void Handle(BookISBNChangedEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookISBN(evt.AggregateId, evt.NewBookISBN);
                _reportDataAccessor.Commit();

                AddEventLog(evt, "BOOKISBN_UPDATED");
            }
            catch (Exception ex)
            {
                AddEventLog(evt, "SERVER_ERROR", ex.ToString());
            }
        }
    }
}