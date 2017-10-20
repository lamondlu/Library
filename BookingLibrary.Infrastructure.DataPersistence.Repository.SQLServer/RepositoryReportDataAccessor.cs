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

namespace BookingLibrary.Infrastructure.DataPersistence.Repository.SQLServer
{
    public class RepositoryReportDataAccessor : IRepositoryReportDataAccessor
    {
        private IRepositoryReadDBConnectionStringProvider _readDBConnectionStringProvider = null;
        private IRepositoryWriteDBConnectionStringProvider _writeDBConnectionStringProvider = null;

        private Dictionary<string, List<SqlParameter>> _commands = null;

        public RepositoryReportDataAccessor()
        {
            _readDBConnectionStringProvider = InjectContainer.GetInstance<IRepositoryReadDBConnectionStringProvider>();
            _writeDBConnectionStringProvider = InjectContainer.GetInstance<IRepositoryWriteDBConnectionStringProvider>();
            _commands = new Dictionary<string, List<SqlParameter>>();
        }

        public void AddBookRepository(AddBookDTO dto)
        {
            _commands.Add("INSERT INTO BookRepository(BookId,BookName,ISBN,DateIssued,Description,BookStatus) values(@bookId, @bookName, @isbn, @dateIssued, @description,@bookStatus)", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = dto.BookId },
                new SqlParameter{ ParameterName ="@bookName", SqlDbType = SqlDbType.NVarChar, Value = dto.BookName },
                new SqlParameter{ ParameterName ="@isbn", SqlDbType = SqlDbType.NVarChar, Value = dto.ISBN },
                new SqlParameter{ ParameterName ="@dateIssued", SqlDbType = SqlDbType.DateTime2, Value = dto.DateIssued },
                new SqlParameter{ ParameterName ="@description", SqlDbType = SqlDbType.NVarChar, Value = dto.Description },
                new SqlParameter{ ParameterName ="@bookStatus", SqlDbType = SqlDbType.Int, Value = dto.BookStatus }
            });
        }

        public List<BookViewModel> GetBookRepositories()
        {
            var result = new List<BookViewModel>();

            var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);
            var dataTable = dbHelper.ExecuteDataTable("SELECT * FROM BookRepository");

            return dataTable.ConvertTo();
        }

        public void Commit()
        {
            var dbHelper = new DbHelper(_writeDBConnectionStringProvider.ConnectionString);
            dbHelper.ExecuteNoQuery(_commands);
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
