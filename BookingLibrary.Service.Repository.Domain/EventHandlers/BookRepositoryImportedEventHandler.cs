using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain.EventHandlers
{
    public class BookRepositoryImportedEventHandler : IEventHandler<BookRepositoryImportedEvent>
    {
        private IRepositoryReportDataAccessor _reportDataAccessor = null;

        public BookRepositoryImportedEventHandler(IRepositoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookRepositoryImportedEvent evt)
        {
            _reportDataAccessor.ImportBookRepositoies(evt.AggregateId, evt.BookRepositoryIds);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookRepositoryImportedEvent evt)
        {
            _reportDataAccessor.ImportBookRepositoies(evt.AggregateId, evt.BookRepositoryIds);
            return _reportDataAccessor.CommitAsync();
        }
    }
}