using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Infrastructure.DataPersistence.Rental.SQLServer;
using BookingLibrary.Service.Rental.Domain.DataAccessors;
using BookingLibrary.Service.Rental.Domain.ViewModels;
using BookingLibrary.Infrastructure.DataPersistence.Rental.SQLServer.Extensions;

namespace BookingLibrary.Infrastructure.DataPersistence.Rental.SQLServer
{
    public class RentalReportDataAccessor : IRentalReportDataAccessor
    {
        private IRentalReadDBConnectionStringProvider _readDBConnectionStringProvider = null;
        private IRentalWriteDBConnectionStringProvider _writeDBConnectionStringProvider = null;

        private List<Command> _commands = null;

        public RentalReportDataAccessor(IRentalReadDBConnectionStringProvider readDBConnectionStringProvider, IRentalWriteDBConnectionStringProvider writeDBConnectionStringProvider)
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

            var sql = "SELECT * FROM RentalRecord WHERE ReturnDate IS NULL";

            return dbHelper.ExecuteDataTable(sql).ConvertToUnreturnedBookViewModel();
        }

        public bool IsNewCustomer(Guid customerId)
        {
            var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);
            var sql = "SELECT COUNT(*) FROM RentalRecord WHERE CustomerId = @customerId";

            return Convert.ToInt32(dbHelper.ExecuteScalar(sql, new List<SqlParameter>{new SqlParameter
            {
                ParameterName = "@customerId",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = customerId
            }}.ToArray())) == 0;
        }

        public void CreateRentBookRequest(Guid bookId, string bookName, string isbn, Guid customerId, PersonName name, DateTime rentDate)
        {
            _commands.Add(new Command("INSERT INTO RentalRecord([Id],[CustomerId],[BookId],[BookName],[ISBN],[ContactFirstName],[ContactLastName],[ContactMiddleName],[RentDate]) VALUES(@id, @customerId, @bookId, @bookName, @isbn, @contactFirstName, @contactLastName, @contactMiddleName, @rentDate)", new List<SqlParameter>
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

        public void RentBook(Guid bookId)
        {
            _commands.Add(new Command("UPDATE RentalRecord SET IsDeleted = 0 WHERE BookId = @bookId and ReturnDate IS NULL", new List<SqlParameter>{
                new SqlParameter{ ParameterName = "@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId}
            }));
        }

        public void ReturnBook(Guid bookId, DateTime returnDate)
        {
            _commands.Add(new Command("UPDATE RentalRecord SET ReturnDate = @returnDate WHERE BookId = @bookId and ReturnDate IS NULL", new List<SqlParameter>{
                new SqlParameter{ ParameterName = "@returnDate", SqlDbType = SqlDbType.DateTime2, Value = returnDate},
                new SqlParameter{ ParameterName = "@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId}
            }));
        }
    }
}