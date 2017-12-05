using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookRemovedEventHandler : BaseInventoryEventHandler<BookRemovedEvent>
    {
        public BookRemovedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(BookRemovedEvent evt)
        {
            evt.Result(BookRemovedEvent.Code_BOOK_REMOVED);
        }
    }
}