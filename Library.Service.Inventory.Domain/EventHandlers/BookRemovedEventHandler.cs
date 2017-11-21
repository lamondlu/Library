using Library.Domain.Core;
using Library.Infrastructure.Core;
using Library.Service.Inventory.Domain.DataAccessors;
using Library.Service.Inventory.Domain.Events;
using System.Threading.Tasks;

namespace Library.Service.Inventory.Domain.EventHandlers
{
    public class BookRemovedEventHandler : IEventHandler<BookRemovedEvent>
    {
        private IInventoryReportDataAccessor _reportDataAccessor = null;
        private ILogger _logger = null;

        public BookRemovedEventHandler(IInventoryReportDataAccessor reportDataAccessor, ILogger logger)
        {
            _reportDataAccessor = reportDataAccessor;
            _logger = logger;
        }

        public void Handle(BookRemovedEvent evt)
        {
            _logger.EventInfo(evt, "Event Finished.");
        }

        public Task HandleAsync(BookRemovedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}