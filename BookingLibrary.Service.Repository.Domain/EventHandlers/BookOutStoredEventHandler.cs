using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain.EventHandlers
{
    public class BookOutStoredEventHandler : IEventHandler<BookOutStoredEvent>
    {
        private IRepositoryReportDataAccessor _reportDataAccessor = null;

        public BookOutStoredEventHandler(IRepositoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookOutStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookStatus(evt.AggregateId, BookStatus.OutStore);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookOutStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookStatus(evt.AggregateId, BookStatus.OutStore);
            return _reportDataAccessor.CommitAsync();
        }
    }
}