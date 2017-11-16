using System;
using System.Data;
using BookLibrary.Service.Identity.Domain.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace BookLibrary.Infrastructure.DataPersistence.Identity.SQLServer.Extensions
{
    public static class Convertors
    {
        public static List<CustomerListViewModel> ConvertToCustomerListView(this DataTable dt)
        {
            return dt.Rows.Cast<DataRow>().Select(ConvertToCustomerListView).ToList();
        }

        public static CustomerListViewModel ConvertToCustomerListView(this DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }

            return new CustomerListViewModel
            {
                CustomerId = Guid.Parse(dr["PersonId"].ToString()),
                FirstName = dr["FirstName"].ToString(),
                MiddleName = dr["MiddleName"].ToString(),
                LastName = dr["LastName"].ToString()
            };
        }
    }
}