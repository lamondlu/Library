using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System;

namespace Library.Service.Rental.Domain.EventHandlers
{
	public class BookRentedEventHandler : BaseRentalEventHandler<BookRentedEvent>
	{
		public BookRentedEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
		{
		}

		public override void HandleCore(BookRentedEvent evt)
		{
			try
			{
				_reportDataAccessor.RentBook(evt.BookInventoryId);
				_reportDataAccessor.Commit();

				evt.Result(BookRentedEvent.Code_BOOK_RENTED);
			}
			catch (Exception ex)
			{
				evt.Result(DomainEvent.Code_SERVER_ERROR, ex.ToString());
			}
		}
	}
}