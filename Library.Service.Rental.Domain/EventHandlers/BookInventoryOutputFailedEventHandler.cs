using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System;

namespace Library.Service.Rental.Domain.EventHandlers
{
    public class BookInventoryOutputFailedEventHandler : BaseRentalEventHandler<BookInventoryOutputFailedEvent>
    {
        public BookInventoryOutputFailedEventHandler(IRentalReportDataAccessor reportDataAccessor, ICommandTracker commandTracker, ILogger logger, IDomainRepository domainRepository, IEventPublisher eventPublisher) : base(reportDataAccessor, commandTracker, logger, domainRepository, eventPublisher)
        {
        }

        public override void HandleCore(BookInventoryOutputFailedEvent evt)
        {
            try
            {
                evt.Result("BOOKINVENTORYOUTPUT_FAILED");
            }
            catch (Exception ex)
            {
                evt.Result("SERVER_ERROR", ex.ToString());
            }
        }
    }
}