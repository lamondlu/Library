using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain.EventHandlers
{
    public class BookDescriptionChangedEventHandler : IEventHandler<BookDescriptionChangedEvent>
    {
        private IRepositoryReportDataAccessor _reportDataAccessor = null;

        public BookDescriptionChangedEventHandler(IRepositoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookDescriptionChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookDescription(evt.AggregateId, evt.Description);
            _reportDataAccessor.Commit();
        }

        public Task HandleAsync(BookDescriptionChangedEvent evt)
        {
            _reportDataAccessor.UpdateBookDescription(evt.AggregateId, evt.Description);
            return _reportDataAccessor.CommitAsync();
        }
    }
}