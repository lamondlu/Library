using System;
using System.Threading.Tasks;
using BookLibrary.Domain.Core;
using BookLibrary.Service.Rental.Domain.DataAccessors;

namespace BookLibrary.Service.Rental.Domain
{
    public class CustomerAccountInitializedEventHandler : IEventHandler<CustomerAccountInitializedEvent>
    {
        private IRentalReportDataAccessor _reportDataAccessor = null;

        public CustomerAccountInitializedEventHandler(IRentalReportDataAccessor reportDataAccessor)
        {
            _reportDataAccessor = reportDataAccessor;
        }

        public void Handle(CustomerAccountInitializedEvent evt)
        {
            
        }

        public Task HandleAsync(CustomerAccountInitializedEvent evt)
        {
            return null;
        }
    }
}