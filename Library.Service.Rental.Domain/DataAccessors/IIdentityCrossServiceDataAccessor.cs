using Library.Service.Rental.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service.Rental.Domain.DataAccessors
{
    public interface IIdentityCrossServiceDataAccessor
    {
        CustomerDetailsViewModel GetCustomerDetails(Guid customerId);
    }
}
