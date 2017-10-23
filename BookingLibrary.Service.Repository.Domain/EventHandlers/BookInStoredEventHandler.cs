using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain.EventHandlers
{
    public class BookInStoredEventHandler : IEventHandler<BookInStoredEvent>
    {
        private IRepositoryReportDataAccessor _reportDataAccessor = null;

        public BookInStoredEventHandler(IRepositoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookInStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookStatus(evt.AggregateId, BookStatus.InStore);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookInStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookStatus(evt.AggregateId, BookStatus.InStore);
            return _reportDataAccessor.CommitAsync();
        }
    }
}