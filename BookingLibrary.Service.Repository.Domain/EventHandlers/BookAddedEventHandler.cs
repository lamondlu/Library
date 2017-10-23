using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain.EventHandlers
{
    public class BookAddedEventHandler : IEventHandler<BookAddedEvent>
    {
        private IRepositoryReportDataAccessor _reportDataAccessor = null;

        public BookAddedEventHandler(IRepositoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookAddedEvent evt)
        {
            _reportDataAccessor.AddBookRepository(new AddBookDTO
            {
                BookId = evt.AggregateId,
                BookName = evt.BookName,
                BookStatus = Convert.ToInt32(evt.BookStatus),
                Description = evt.Description,
                ISBN = evt.ISBN,
                DateIssued = evt.DateIssued
            });

            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookAddedEvent evt)
        {
            _reportDataAccessor.AddBookRepository(new AddBookDTO
            {
                BookId = evt.AggregateId,
                BookName = evt.BookName,
                BookStatus = Convert.ToInt32(evt.BookStatus),
                Description = evt.Description,
                ISBN = evt.ISBN,
                DateIssued = evt.DateIssued
            });

            return _reportDataAccessor.CommitAsync();
        }
    }
}