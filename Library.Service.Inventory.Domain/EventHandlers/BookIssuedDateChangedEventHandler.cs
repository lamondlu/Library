using Library.Domain.Core;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookIssuedDatehangedEventHandler : IEventHandler<BookIssuedDateChangedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;
        private ILogger _logger = null;

        public BookIssuedDatehangedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ILogger logger)
        {
            _reportDataAccessor = reportDataAccessor;
            _logger = logger;
        }

        public void Handle(BookIssuedDateChangedEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookIssuedDate(evt.AggregateId, evt.NewBookIssuedDate);
                _reportDataAccessor.Commit();

                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
            }
        }

        public Task HandleAsync(BookIssuedDateChangedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}