using System;
using BookingLibrary.Service.Repository.Domain.DataAccessors;
using BookingLibrary.Infrastructure.InjectionFramework;
using System.Collections.Generic;
using BookingLibrary.Service.Repository.Domain.DTOs;
using System.Data.SqlClient;
using System.Data;
using BookingLibrary.Service.Repository.Domain.ViewModels;
using BookingLibrary.Infrastructure.DataPersistence.Repository.SQLServer.Extensions;
using System.Threading.Tasks;
using BookingLibrary.Service.Repository.Domain;
using System.Linq;

namespace BookingLibrary.Infrastructure.DataPersistence.Repository.SQLServer
{
    public class RepositoryReportDataAccessor : IRepositoryReportDataAccessor
    {
        private IRepositoryReadDBConnectionStringProvider _readDBConnectionStringProvider = null;
        private IRepositoryWriteDBConnectionStringProvider _writeDBConnectionStringProvider = null;

        private Dictionary<string, List<SqlParameter>> _commands = null;

        public RepositoryReportDataAccessor(IRepositoryReadDBConnectionStringProvider readDBConnectionStringProvider, IRepositoryWriteDBConnectionStringProvider writeDBConnectionStringProvider)
        {
            _readDBConnectionStringProvider = readDBConnectionStringProvider;
            _writeDBConnectionStringProvider = writeDBConnectionStringProvider;
            _commands = new Dictionary<string, List<SqlParameter>>();
        }

        public void AddBookRepository(AddBookDTO dto)
        {
            _commands.Add("INSERT INTO Book(BookId,BookName,ISBN,DateIssued,Description,Status) values(@bookId, @bookName, @isbn, @dateIssued, @description,@bookStatus)", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = dto.BookId },
                new SqlParameter{ ParameterName ="@bookName", SqlDbType = SqlDbType.NVarChar, Value = dto.BookName },
                new SqlParameter{ ParameterName ="@isbn", SqlDbType = SqlDbType.NVarChar, Value = dto.ISBN },
                new SqlParameter{ ParameterName ="@dateIssued", SqlDbType = SqlDbType.DateTime2, Value = dto.DateIssued },
                new SqlParameter{ ParameterName ="@description", SqlDbType = SqlDbType.NVarChar, Value = dto.Description },
                new SqlParameter{ ParameterName ="@bookStatus", SqlDbType = SqlDbType.Int, Value = dto.BookStatus }
            });
        }

        public void UpdateBookName(Guid bookId, string bookName)
        {
            _commands.Add("UPDATE Book SET BookName=@bookName WHERE BookId = @bookId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@bookName", SqlDbType = SqlDbType.NVarChar, Value = bookName }
            });
        }

        public void UpdateBookDescription(Guid bookId, string description)
        {
            _commands.Add("UPDATE Book SET Description=@description WHERE BookId = @bookId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@description", SqlDbType = SqlDbType.NVarChar, Value = description }
            });
        }

        public void UpdateBookISBN(Guid bookId, string isbn)
        {
            _commands.Add("UPDATE Book SET ISBN=@isbn WHERE BookId = @bookId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@isbn", SqlDbType = SqlDbType.NVarChar, Value = isbn }
            });
        }

        public void UpdateBookIssuedDate(Guid bookId, DateTime issuedDate)
        {
            _commands.Add("UPDATE Book SET DateIssued=@issuedDate WHERE BookId = @bookId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@issuedDate", SqlDbType = SqlDbType.DateTime2, Value = issuedDate }
            });
        }

        public void UpdateBookStatus(Guid bookId, BookStatus status)
        {
            _commands.Add("UPDATE Book SET Status=@status WHERE BookId = @bookId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@status", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(status) }
            });
        }

        public List<BookViewModel> GetBookRepositories()
        {
            var result = new List<BookViewModel>();

            var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);
            var dataTable = dbHelper.ExecuteDataTable("SELECT * FROM Book");

            return dataTable.ConvertToBookViewModel();
        }

        public BookDetailedModel GetBookById(Guid bookId)
        {
            var result = new List<BookViewModel>();

            var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);
            var dataTable = dbHelper.ExecuteDataTable("SELECT * FROM Book WHERE BookId=@bookId", new SqlParameter{ ParameterName = "@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId});

            return dataTable.ConvertToBookDetailedModel().FirstOrDefault();
        }

        public bool ExistISBN(string isbn, Guid? bookId = null)
        {
            var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);
            var sql = string.Empty;

            if (bookId.HasValue)
            {
                sql = "SELECT COUNT(ISBN) FROM Book WHERE ISBN=@isbn and BookId<>@bookId";

                return dbHelper.ExecuteScalar(sql, new List<SqlParameter>{
                   new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId.Value},
                   new SqlParameter{ ParameterName ="@isbn", SqlDbType = SqlDbType.NVarChar, Value = bookId}
                }.ToArray()) >= 1;
            }
            else
            {
                sql = "SELECT COUNT(ISBN) FROM Book WHERE ISBN=@isbn";

                return dbHelper.ExecuteScalar(sql, new List<SqlParameter>{
                   new SqlParameter{ ParameterName ="@isbn", SqlDbType = SqlDbType.NVarChar, Value = isbn}
                }.ToArray()) >= 1;
            }
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
    }
}
