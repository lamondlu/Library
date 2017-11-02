using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain.EventHandlers
{
    public class BookRepositoryOutStoredEventHandler : IEventHandler<BookRepositoryOutStoredEvent>
    {
        private IRepositoryReportDataAccessor _reportDataAccessor = null;

        public BookRepositoryOutStoredEventHandler(IRepositoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookRepositoryOutStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookRepositoryStatus(evt.AggregateId, BookRepositoryStatus.OutStore, evt.Notes);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookRepositoryOutStoredEvent evt)
        {
            _reportDataAccessor.UpdateBookRepositoryStatus(evt.AggregateId, BookRepositoryStatus.OutStore, evt.Notes);
            return _reportDataAccessor.CommitAsync();
        }
    }
}