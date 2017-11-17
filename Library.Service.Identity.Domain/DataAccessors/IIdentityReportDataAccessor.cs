using System;
using System.Collections.Generic;
using  Library.Service.Identity.Domain.ViewModels;

namespace  Library.Service.Identity.Domain.DataAccessors
{
    public interface IIdentityReportDataAccessor
    {
        IdentityViewModel GetIdentity(string userName, string hashedPassword);

        List<CustomerListViewModel> GetCustomerList();

        CustomerListViewModel GetCustomerSingleListViewModel(Guid personId);

        IdentityDetailsViewModel GetAccountDetails(Guid accountId);
    }
}