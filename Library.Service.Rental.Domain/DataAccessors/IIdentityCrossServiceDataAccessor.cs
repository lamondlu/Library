using Library.Service.Rental.Domain.DTOs;
using System;

namespace Library.Service.Rental.Domain.DataAccessors
{
	public interface IIdentityCrossServiceDataAccessor
	{
		CustomerDetailsViewModel GetCustomerDetails(Guid customerId);
	}
}