using Library.Infrastructure.Core.Extensions;
using Library.Service.Rental.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Library.Infrastructure.DataPersistence.Rental.SQLServer.Extensions
{
    public static class Convertors
    {
        public static UnreturnedBookViewModel ConvertToUnreturnedBookViewModel(this DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }

            return new UnreturnedBookViewModel
            {
                BookId = Guid.Parse(dr["BookId"].ToString()),
                CustomerId = Guid.Parse(dr["CustomerId"].ToString()),
                BookName = dr["BookName"].SafeConvertToString(),
                ISBN = dr["ISBN"].SafeConvertToString(),
                FirstName = dr["ContactFirstName"].SafeConvertToString(),
                LastName = dr["ContactLastName"].SafeConvertToString(),
                MiddleName = dr["ContactMiddleName"].SafeConvertToString(),
                RentDate = Convert.ToDateTime(dr["RentDate"])
            };
        }

        public static List<UnreturnedBookViewModel> ConvertToUnreturnedBookViewModel(this DataTable dt)
        {
            return dt.Rows.Cast<DataRow>().Select(ConvertToUnreturnedBookViewModel).ToList();
        }
    }
}