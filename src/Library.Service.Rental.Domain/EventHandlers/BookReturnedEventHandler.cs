using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.EventHandlers;
using Library.Service.Rental.Domain.Events;
using System;

namespace Library.Service.Rental.Domain
{
    public class BookReturnedEventHandler : BaseRentalEventHandler<BookReturnedEvent>
    {
        public BookReturnedEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(BookReturnedEvent evt)
        {
            try
            {
                _reportDataAccessor.ReturnBook(evt.BookId, evt.ReturnDate);
                _reportDataAccessor.Commit();

                evt.Result(BookReturnedEvent.Code_BOOK_RETURNED);
            }
            catch (Exception ex)
            {
                evt.Result(DomainEvent.Code_SERVER_ERROR, ex.ToString());
            }
        }
    }
}