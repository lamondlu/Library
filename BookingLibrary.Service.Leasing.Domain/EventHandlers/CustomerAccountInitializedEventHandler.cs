using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Leasing.Domain.DataAccessors;

namespace BookingLibrary.Service.Leasing.Domain
{
    public class CustomerAccountInitializedEventHandler : IEventHandler<CustomerAccountInitializedEvent>
    {
        private ILeasingReportDataAccessor _reportDataAccessor = null;

        public CustomerAccountInitializedEventHandler(ILeasingReportDataAccessor reportDataAccessor)
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