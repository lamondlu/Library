using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Infrastructure.DataPersistence.Leasing.SQLServer;
using BookingLibrary.Service.Leasing.Domain.DataAccessors;
using BookingLibrary.Service.Leasing.Domain.ViewModels;
using BookingLibrary.Infrastructure.DataPersistence.Leasing.SQLServer.Extensions;

namespace BookingLibrary.Infrastructure.DataPersistence.Leasing.SQLServer
{
    public class LeasingReportDataAccessor : ILeasingReportDataAccessor
    {
        private ILeasingReadDBConnectionStringProvider _readDBConnectionStringProvider = null;
        private ILeasingWriteDBConnectionStringProvider _writeDBConnectionStringProvider = null;

        private List<Command> _commands = null;

        public LeasingReportDataAccessor(ILeasingReadDBConnectionStringProvider readDBConnectionStringProvider, ILeasingWriteDBConnectionStringProvider writeDBConnectionStringProvider)
        {
            _readDBConnectionStringProvider = readDBConnectionStringProvider;
            _writeDBConnectionStringProvider = writeDBConnectionStringProvider;
            _commands = new List<Command>();
        }

        public void Commit()
        {
            var dbHelper = new DbHelper(_writeDBConnectionStringProvider.ConnectionString);
            dbHelper.ExecuteNoQuery(_commands);
            _commands.Clear();
        }

        public Task CommitAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                Commit();
            });
        }

        public List<UnreturnedBookViewModel> GetUnreturnBooks()
        {
            var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);

            var sql = "SELECT * FROM LeasingRecord WHERE ReturnDate IS NULL";

            return dbHelper.ExecuteDataTable(sql).ConvertToUnreturnedBookViewModel();
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
            }}.ToArray())) == 0;
        }

        public void RentBook(Guid bookId, string bookName, string isbn, Guid customerId, PersonName name, DateTime rentDate)
        {
            _commands.Add(new Command("INSERT INTO LeasingRecord([Id],[CustomerId],[BookId],[BookName],[ISBN],[ContactFirstName],[ContactLastName],[ContactMiddleName],[RentDate]) VALUES(@id, @customerId, @bookId, @bookName, @isbn, @contactFirstName, @contactLastName, @contactMiddleName, @rentDate)", new List<SqlParameter>
            {
                new SqlParameter{ ParameterName = "@id", SqlDbType = SqlDbType.UniqueIdentifier, Value = Guid.NewGuid()},
                new SqlParameter{ ParameterName = "@customerId", SqlDbType = SqlDbType.UniqueIdentifier, Value = customerId},
                new SqlParameter{ ParameterName = "@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId},
                new SqlParameter{ ParameterName = "@bookName", SqlDbType = SqlDbType.NVarChar, Value = bookName},
                new SqlParameter{ ParameterName = "@isbn", SqlDbType = SqlDbType.NVarChar, Value = isbn},
                new SqlParameter{ ParameterName = "@contactFirstName", SqlDbType = SqlDbType.NVarChar, Value = name.FirstName??string.Empty},
                new SqlParameter{ ParameterName = "@contactLastName", SqlDbType = SqlDbType.NVarChar, Value = name.LastName??string.Empty},
                new SqlParameter{ ParameterName = "@contactMiddleName", SqlDbType = SqlDbType.NVarChar, Value = name.MiddleName??string.Empty},
                new SqlParameter{ ParameterName = "@rentDate", SqlDbType = SqlDbType.DateTime2, Value = rentDate}
            }));
        }

        public void ReturnBook(Guid bookId, DateTime returnDate)
        {
            _commands.Add(new Command("UPDATE LeasingRecord SET ReturnDate = @returnDate WHERE BookId = @bookId and ReturnDate IS NULL", new List<SqlParameter>{
                new SqlParameter{ ParameterName = "@returnDate", SqlDbType = SqlDbType.DateTime2, Value = returnDate},
                new SqlParameter{ ParameterName = "@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId}
            }));
        }
    }
}