using Library.Service.Identity.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Service.Identity.Domain.DataAccessors
{
	public interface IIdentityReportDataAccessor
	{
		IdentityViewModel GetIdentity(string userName, string hashedPassword);

		List<CustomerListViewModel> GetCustomerList();

		CustomerListViewModel GetCustomerSingleListViewModel(Guid personId);

		IdentityDetailsViewModel GetAccountDetails(Guid accountId);

        void CreateUser(Guid personId, string userName, string password, string firstName, string lastName, string middleName);

		void Commit();

		Task CommitAsync();
	}
}