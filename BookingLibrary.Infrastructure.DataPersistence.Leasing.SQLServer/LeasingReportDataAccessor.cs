using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Infrastructure.DataPersistence.Leasing.SQLServer;
using BookingLibrary.Service.Leasing.Domain.DataAccessors;
using BookingLibrary.Service.Repository.Domain.DataAccessors;

namespace BookingLibrary.Infrastrcture.DataPersistence.Leasing.SQLServer
{
    public class LeasingReportDataAccessor : ILeasingReportDataAccessor
    {
        private ILeasingReadDBConnectionStringProvider _readDBConnectionStringProvider = null;
        private ILeasingWriteDBConnectionStringProvider _writeDBConnectionStringProvider = null;

        private List<Command> _commands = null;

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public bool IsNewCustomer(Guid customerId)
        {
            var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);
            var sql = "SELECT COUNT(*) FROM LeasingRecord WHERE CustomerId = @customerId";

            return Convert.ToInt32(dbHelper.ExecuteScalar(sql, new List<SqlParameter>{new SqlParameter
            {
                ParameterName = "@customerId",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = customerId
            }}.ToArray())) > 0;
        }

        public void RentBook(Guid bookId, string bookName, string isbn, Guid customerId, PersonName name, DateTime rentDate)
        {
            
        }

        public void ReturnBook(Guid bookId, DateTime returnDate)
        {
            throw new NotImplementedException();
        }
    }
}