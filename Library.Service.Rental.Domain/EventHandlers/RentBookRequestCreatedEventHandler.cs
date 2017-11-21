using Library.Domain.Core;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain
{
    public class RentBookRequestCreatedEventHandler : IEventHandler<RentBookRequestCreatedEvent>
    {
        private IRentalReportDataAccessor _reportDataAccessor = null;
        private IEventPublisher _eventPublisher = null;
        private ILogger _logger = null;

        public RentBookRequestCreatedEventHandler(IRentalReportDataAccessor reportDataAccessor, IEventPublisher eventPublisher, ILogger logger)
        {
            _reportDataAccessor = reportDataAccessor;
            _eventPublisher = eventPublisher;
            _logger = logger;
        }

        public void Handle(RentBookRequestCreatedEvent evt)
        {
            try
            {
                _reportDataAccessor.CreateRentBookRequest(evt.BookInventoryId, evt.BookName, evt.ISBN, evt.AggregateId, evt.Name, evt.RentDate);
                _reportDataAccessor.Commit();

                _eventPublisher.Publish(new RentBookRequestAcceptedEvent
                {
                    AggregateId = evt.BookInventoryId,
                    CommandUniqueId = evt.CommandUniqueId,
                    Notes = $"Rent by {evt.Name.FirstName} {evt.Name.LastName} at {evt.RentDate.ToString("yyyy-MM-dd HH:mm:ss")}",
                    CustomerId = evt.AggregateId
                });

                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
            }
        }

        public Task HandleAsync(RentBookRequestCreatedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}