using Library.Infrastructure.Core.Utilities;
using Library.Infrastructure.CSDataAccessor.Core;
using Library.Service.Rental.Domain.DataAccessors;
using Library.Service.Rental.Domain.DTOs;
using System;

namespace Library.Infrastructure.CSDataAccessor.Rental
{
	public class IdentityCrossServiceAccessor : IIdentityCrossServiceDataAccessor
	{
		private string _url = string.Empty;

		public IdentityCrossServiceAccessor(IApiGatewayUrlProvider provider)
		{
			_url = provider.Url;
		}

		public CustomerDetailsViewModel GetCustomerDetails(Guid customerId)
		{
			return ApiRequest.Get<CustomerDetailsViewModel>($"{_url}/api/customers/{customerId}");
		}
	}
}