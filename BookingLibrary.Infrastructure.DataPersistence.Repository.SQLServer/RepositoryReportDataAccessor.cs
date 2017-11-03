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

        private List<Command> _commands = null;

        public RepositoryReportDataAccessor(IRepositoryReadDBConnectionStringProvider readDBConnectionStringProvider, IRepositoryWriteDBConnectionStringProvider writeDBConnectionStringProvider)
        {
            _readDBConnectionStringProvider = readDBConnectionStringProvider;
            _writeDBConnectionStringProvider = writeDBConnectionStringProvider;
            _commands = new List<Command>();
        }

        public void AddBook(AddBookDTO dto)
        {
            _commands.Add(new Command("INSERT INTO Book(BookId,BookName,ISBN,DateIssued,Description) values(@bookId, @bookName, @isbn, @dateIssued, @description)", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = dto.BookId },
                new SqlParameter{ ParameterName ="@bookName", SqlDbType = SqlDbType.NVarChar, Value = dto.BookName },
                new SqlParameter{ ParameterName ="@isbn", SqlDbType = SqlDbType.NVarChar, Value = dto.ISBN },
                new SqlParameter{ ParameterName ="@dateIssued", SqlDbType = SqlDbType.DateTime2, Value = dto.DateIssued },
                new SqlParameter{ ParameterName ="@description", SqlDbType = SqlDbType.NVarChar, Value = dto.Description }
            }));
        }

        public void UpdateBookName(Guid bookId, string bookName)
        {
            _commands.Add(new Command("UPDATE Book SET BookName=@bookName WHERE BookId = @bookId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@bookName", SqlDbType = SqlDbType.NVarChar, Value = bookName }
            }));
        }

        public void UpdateBookDescription(Guid bookId, string description)
        {
            _commands.Add(new Command("UPDATE Book SET Description=@description WHERE BookId = @bookId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@description", SqlDbType = SqlDbType.NVarChar, Value = description }
            }));
        }

        public void UpdateBookISBN(Guid bookId, string isbn)
        {
            _commands.Add(new Command("UPDATE Book SET ISBN=@isbn WHERE BookId = @bookId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@isbn", SqlDbType = SqlDbType.NVarChar, Value = isbn }
            }));
        }

        public void UpdateBookIssuedDate(Guid bookId, DateTime issuedDate)
        {
            _commands.Add(new Command("UPDATE Book SET DateIssued=@issuedDate WHERE BookId = @bookId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@issuedDate", SqlDbType = SqlDbType.DateTime2, Value = issuedDate }
            }));
        }

        public void UpdateBookRepositoryStatus(Guid bookRepositoryId, BookRepositoryStatus status, string notes)
        {
            _commands.Add(new Command("UPDATE BookRepository SET Status=@status WHERE BookRepositoryId = @bookRepositoryId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookRepositoryId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookRepositoryId },
                new SqlParameter{ ParameterName ="@status", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(status) }
            }));

            if (!string.IsNullOrWhiteSpace(notes))
            {
                _commands.Add(new Command("INSERT INTO History(HistoryId, BookRepositoryId, Note, CreatedOn) values(@historyId, @bookRepositoryId, @note, @createdOn)", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookRepositoryId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookRepositoryId },
                new SqlParameter{ ParameterName ="@historyId", SqlDbType = SqlDbType.UniqueIdentifier, Value = Guid.NewGuid() },
                new SqlParameter{ ParameterName ="@createdOn", SqlDbType = SqlDbType.DateTime2, Value = DateTime.Now },
                new SqlParameter{ ParameterName ="@note", SqlDbType = SqlDbType.NVarChar, Value = notes },
            }));
            }
        }

        public void RemoveBookRepository(Guid bookRepositoryId)
        {
            _commands.Add(new Command("UPDATE BookRepository SET IsDeleted=1 WHERE BookRepositoryId = @bookRepositoryId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookRepositoryId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookRepositoryId }
            }));
        }

        public List<BookViewModel> GetBooks()
        {
            var result = new List<BookViewModel>();

            var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);
            var dataTable = dbHelper.ExecuteDataTable("SELECT * FROM Book");

            result = dataTable.ConvertToBookViewModel();

            return result;
        }

        public BookDetailedModel GetBookById(Guid bookId)
        {
            var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);
            var dataTable = dbHelper.ExecuteDataTable("SELECT * FROM Book WHERE BookId=@bookId", new SqlParameter { ParameterName = "@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId });

            var result = dataTable.ConvertToBookDetailedModel().FirstOrDefault();

            if (result != null)
            {

                var repositoryDatas = dbHelper.ExecuteDataTable(@"
                    SELECT *, (SELECT TOP 1 h.Note From History h Where h.BookRepositoryId = br.BookRepositoryId) as LastNote FROM BookRepository br WHERE br.BookId = @bookId
                    ", new SqlParameter { ParameterName = "@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId });

                var repositories = repositoryDatas.ConvertToBookRepositoryViewModel();

                result.BookRepositories = repositories;
            }

            return result;
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

        public void DeleteBook(Guid bookId)
        {
            _commands.Add(new Command("Delete Book WHERE BookId = @bookId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId }
            }));
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

        public void ImportBookRepositoies(Guid bookId, List<BookRepository> bookRepositories)
        {
            foreach (var bookRepository in bookRepositories)
            {
                _commands.Add(new Command("INSERT INTO BookRepository(BookRepositoryId, BookId, Status, IsRemoved) VALUES(@bookRepositoryId, @bookId, @status, @isRemoved)", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookRepositoryId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookRepository.Id },
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@status", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(bookRepository.Status) },
                new SqlParameter{ ParameterName ="@isRemoved", SqlDbType = SqlDbType.Bit, Value = false }
                }));

                _commands.Add(new Command("INSERT INTO History(HistoryId, BookRepositoryId, BookId, Note, CreatedOn) values(@historyId, @bookRepositoryId, @bookId, @note, @createdOn)", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookRepositoryId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookRepository.Id },
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@historyId", SqlDbType = SqlDbType.UniqueIdentifier, Value = Guid.NewGuid() },
                new SqlParameter{ ParameterName ="@createdOn", SqlDbType = SqlDbType.DateTime2, Value = DateTime.Now },
                new SqlParameter{ ParameterName ="@note", SqlDbType = SqlDbType.NVarChar, Value = "Bulk Imported." }
                }));
            }
        }
    }
}
