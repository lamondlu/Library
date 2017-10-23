using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain.EventHandlers
{
    public class BookNameChangedEventHandler : IEventHandler<BookNameChangedEvent>
    {
        private IRepositoryReportDataAccessor _reportDataAccessor = null;

        public BookNameChangedEventHandler(IRepositoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookNameChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookName(evt.AggregateId, evt.NewBookName);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookNameChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookName(evt.AggregateId, evt.NewBookName);
            return _reportDataAccessor.CommitAsync();
        }
    }
}