using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain.EventHandlers
{
    public class BookISBNChangedEventHandler : IEventHandler<BookISBNChangedEvent>
    {
        private IRepositoryReportDataAccessor _reportDataAccessor = null;

        public BookISBNChangedEventHandler(IRepositoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookISBNChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookISBN(evt.AggregateId, evt.NewBookISBN);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookISBNChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookISBN(evt.AggregateId, evt.NewBookISBN);
            return _reportDataAccessor.CommitAsync();
        }
    }
}