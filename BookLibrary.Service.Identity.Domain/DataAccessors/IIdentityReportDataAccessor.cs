using System;
using System.Collections.Generic;
using BookLibrary.Service.Identity.Domain.ViewModels;

namespace BookLibrary.Service.Identity.Domain.DataAccessors
{
    public interface IIdentityReportDataAccessor
    {
        IdentityViewModel GetIdentity(string userName, string hashedPassword);

        List<CustomerListViewModel> GetCustomerList();

        CustomerListViewModel GetCustomerSingleListViewModel(Guid personId);

        IdentityDetailsViewModel GetAccountDetails(Guid accountId);
    }
}