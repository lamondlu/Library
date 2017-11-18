using Library.Service.Identity.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Library.Infrastructure.DataPersistence.Identity.SQLServer.Extensions
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