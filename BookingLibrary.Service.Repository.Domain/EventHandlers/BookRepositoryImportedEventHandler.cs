using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.Events;
using System.Linq;

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
            var bookRepositories = evt.BookRepositoryIds.Select(p => new BookRepository(p)).ToList();

            foreach (var item in bookRepositories)
            {
                item.InStore();
            }

            _reportDataAccessor.ImportBookRepositoies(evt.AggregateId, bookRepositories);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookRepositoryImportedEvent evt)
        {
            var bookRepositories = evt.BookRepositoryIds.Select(p => new BookRepository(p)).ToList();

            foreach (var item in bookRepositories)
            {
                item.InStore();
            }

            _reportDataAccessor.ImportBookRepositoies(evt.AggregateId, bookRepositories);
            return _reportDataAccessor.CommitAsync();
        }
    }
}