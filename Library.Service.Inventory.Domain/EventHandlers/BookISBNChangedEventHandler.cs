using Library.Domain.Core;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookISBNChangedEventHandler : IEventHandler<BookISBNChangedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;
        private ILogger _logger = null;

        public BookISBNChangedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ILogger logger)
        {
            _reportDataAccessor = reportDataAccessor;
            _logger = logger;
        }

        public void Handle(BookISBNChangedEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookISBN(evt.AggregateId, evt.NewBookISBN);
                _reportDataAccessor.Commit();

                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
            }
        }

        public Task HandleAsync(BookISBNChangedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}