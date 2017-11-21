using Library.Domain.Core;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookNameChangedEventHandler : IEventHandler<BookNameChangedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;
        private ILogger _logger = null;

        public BookNameChangedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ILogger logger)
        {
            _reportDataAccessor = reportDataAccessor;
            _logger = logger;
        }

        public void Handle(BookNameChangedEvent evt)
        {
            try
            {
                _reportDataAccessor.UpdateBookName(evt.AggregateId, evt.NewBookName);
                _reportDataAccessor.Commit();

                _logger.EventInfo(evt, "Event Finished.");
            }
            catch (Exception ex)
            {
                _logger.EventError(evt, $"SERVER_ERROR: {ex.ToString()}");
            }
        }

        public Task HandleAsync(BookNameChangedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}