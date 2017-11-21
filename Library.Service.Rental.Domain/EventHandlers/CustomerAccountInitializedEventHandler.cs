using Library.Domain.Core;
using Library.Infrastructure.Core;
using Library.Service.Rental.Domain.DataAccessors;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain
{
    public class CustomerAccountInitializedEventHandler : IEventHandler<CustomerAccountInitializedEvent>
    {
        private IRentalReportDataAccessor _reportDataAccessor = null;
        private ILogger _logger = null;

        public CustomerAccountInitializedEventHandler(IRentalReportDataAccessor reportDataAccessor, ILogger logger)
        {
            _reportDataAccessor = reportDataAccessor;
            _logger = logger;
        }

        public void Handle(CustomerAccountInitializedEvent evt)
        {
            _logger.EventInfo(evt, "Event Finished.");
        }

        public Task HandleAsync(CustomerAccountInitializedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}