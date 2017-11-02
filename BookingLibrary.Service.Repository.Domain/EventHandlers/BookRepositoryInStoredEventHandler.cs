using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain.EventHandlers
{
    public class BookRepositoryInStoredEventHandler : IEventHandler<BookRepositoryInStoredEvent>
    {
        private IRepositoryReportDataAccessor _reportDataAccessor = null;

        public BookRepositoryInStoredEventHandler(IRepositoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookRepositoryInStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookRepositoryStatus(evt.AggregateId, BookRepositoryStatus.InStore, evt.Notes);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookRepositoryInStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookRepositoryStatus(evt.AggregateId, BookRepositoryStatus.InStore, evt.Notes);
            return _reportDataAccessor.CommitAsync();
        }
    }
}