using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.Events;

namespace BookingLibrary.Service.Repository.Domain.EventHandlers
{
    public class BookRemovedEventHandler : IEventHandler<BookRemovedEvent>
    {
        private IRepositoryReportDataAccessor _reportDataAccessor = null;

        public BookRemovedEventHandler(IRepositoryReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(BookRemovedEvent evt)
        {
            
        }

        public Task HandleAsync(BookRemovedEvent evt)
        {
            return null;
        }
    }
}