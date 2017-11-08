using System;
using System.Collections.Generic;
using BookingLibrary.Service.Identity.Domain.ViewModels;

namespace BookingLibrary.Service.Identity.Domain.DataAccessors
{
    public interface IIdentityReportDataAccessor
    {
        IdentityViewModel GetIdentity(string userName, string hashedPassword);

        List<CustomerListViewModel> GetCustomerList();

        CustomerListViewModel GetCustomerSingleListViewModel(Guid personId);
    }
}