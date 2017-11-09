using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BookingLibrary.Service.Leasing.Domain.ViewModels;

namespace BookingLibrary.Infrastructure.DataPersistence.Leasing.SQLServer.Extensions
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
                BookName = dr["BookName"].ToString(),
                ISBN = dr["ISBN"].ToString(),
                FirstName = dr["ContactFirstName"].ToString(),
                LastName = dr["ContactLastName"].ToString(),
                MiddleName = dr["ContactMiddleName"].ToString(),
                RentDate = Convert.ToDateTime(dr["RentDate"])  
            };
        }

        public static List<UnreturnedBookViewModel> ConvertToUnreturnedBookViewModel(this DataTable dt)
        {
            return dt.Rows.Cast<DataRow>().Select(ConvertToUnreturnedBookViewModel).ToList();
        }
    }
}