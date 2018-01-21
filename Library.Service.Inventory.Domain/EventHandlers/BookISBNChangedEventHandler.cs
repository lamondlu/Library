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

		public override void HandleCore(BookISBNChangedEvent evt)
		{
			try
			{
				_reportDataAccessor.UpdateBookISBN(evt.AggregateId, evt.NewBookISBN);
				_reportDataAccessor.Commit();

				evt.Result(BookISBNChangedEvent.Code_BOOKISBN_CHANGED);
			}
			catch (Exception ex)
			{
				evt.Result(BookISBNChangedEvent.Code_SERVER_ERROR, ex.ToString());
			}
		}
	}
}