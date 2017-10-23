using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain.EventHandlers
{
    public class BookIssuedDatehangedEventHandler : IEventHandler<BookIssuedDateChangedEvent>
    {
        private IRepositoryReportDataAccessor _reportDataAccessor = null;

        public BookIssuedDatehangedEventHandler(IRepositoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookIssuedDateChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookIssuedDate(evt.AggregateId, evt.NewBookIssuedDate);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookIssuedDateChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookIssuedDate(evt.AggregateId, evt.NewBookIssuedDate);
            return _reportDataAccessor.CommitAsync();
        }
    }
}