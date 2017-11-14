using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Rental.Domain.Events;
using BookingLibrary.Service.Rental.Domain.DataAccessors;
using BookingLibrary.Domain.Core.Messaging;

namespace BookingLibrary.Service.Rental.Domain
{
    public class BookRentedEventHandler : IEventHandler<BookRentedEvent>
    {
        private IRentalReportDataAccessor _reportDataAccessor = null;
        private IEventPublisher _eventPublisher = null;

        public BookRentedEventHandler(IRentalReportDataAccessor reportDataAccessor, IEventPublisher eventPublisher)
        {
            _reportDataAccessor = reportDataAccessor;
            _eventPublisher = eventPublisher;
        }

        public void Handle(BookRentedEvent evt)
        {
            _reportDataAccessor.RentBook(evt.BookId, evt.BookName, evt.ISBN, evt.AggregateId, evt.Name, evt.RentDate);
            _reportDataAccessor.Commit();

            _eventPublisher.Publish(new RentedBookOutStoredEvent
            {
                AggregateId = evt.BookId,
                CommandUniqueId = evt.CommandUniqueId,
                Notes = $"Rent by {evt.Name.FirstName} {evt.Name.LastName} at {evt.RentDate.ToString("yyyy-MM-dd HH:mm:ss")}"
            });
        }

        public Task HandleAsync(BookRentedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}