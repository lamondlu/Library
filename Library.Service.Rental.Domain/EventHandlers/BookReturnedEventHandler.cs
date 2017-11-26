using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.EventHandlers;
using Library.Service.Rental.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain
{
    public class BookReturnedEventHandler : BaseRentalEventHandler<BookReturnedEvent>
    {
        public BookReturnedEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {

        }

        public override void Handle(BookReturnedEvent evt)
        {
            try
            {
                _reportDataAccessor.ReturnBook(evt.BookId, evt.ReturnDate);
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