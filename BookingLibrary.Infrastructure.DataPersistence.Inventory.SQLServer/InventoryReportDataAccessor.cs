using System;
using BookingLibrary.Service.Inventory.Domain.DataAccessors;
using BookingLibrary.Infrastructure.InjectionFramework;
using System.Collections.Generic;
using BookingLibrary.Service.Inventory.Domain.DTOs;
using System.Data.SqlClient;
using System.Data;
using BookingLibrary.Service.Inventory.Domain.ViewModels;
using BookingLibrary.Infrastructure.DataPersistence.Inventory.SQLServer.Extensions;
using System.Threading.Tasks;
using BookingLibrary.Service.Inventory.Domain;
using System.Linq;

namespace BookingLibrary.Infrastructure.DataPersistence.Inventory.SQLServer
{
    public class InventoryReportDataAccessor : IInventoryReportDataAccessor
    {
        private IInventoryReadDBConnectionStringProvider _readDBConnectionStringProvider = null;
        private IInventoryWriteDBConnectionStringProvider _writeDBConnectionStringProvider = null;

        private List<Command> _commands = null;

        public InventoryReportDataAccessor(IInventoryReadDBConnectionStringProvider readDBConnectionStringProvider, IInventoryWriteDBConnectionStringProvider writeDBConnectionStringProvider)
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

        public void UpdateBookInventoryStatus(Guid bookInventoryId, BookInventoryStatus status, string notes)
        {
            _commands.Add(new Command("UPDATE BookInventory SET Status=@status WHERE BookInventoryId = @bookInventoryId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookInventoryId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookInventoryId },
                new SqlParameter{ ParameterName ="@status", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(status) }
            }));

            if (!string.IsNullOrWhiteSpace(notes))
            {
                _commands.Add(new Command("INSERT INTO History(HistoryId, BookInventoryId, Note, CreatedOn) values(@historyId, @bookInventoryId, @note, @createdOn)", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookInventoryId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookInventoryId },
                new SqlParameter{ ParameterName ="@historyId", SqlDbType = SqlDbType.UniqueIdentifier, Value = Guid.NewGuid() },
                new SqlParameter{ ParameterName ="@createdOn", SqlDbType = SqlDbType.DateTime2, Value = DateTime.Now },
                new SqlParameter{ ParameterName ="@note", SqlDbType = SqlDbType.NVarChar, Value = notes },
            }));
            }
        }

        public void RemoveBookInventory(Guid bookInventoryId)
        {
            _commands.Add(new Command("UPDATE BookInventory SET IsDeleted=1 WHERE BookInventoryId = @bookInventoryId", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookInventoryId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookInventoryId }
            }));
        }

        public List<AvailableBookLookupModel> GetAvailableBooks()
        {
            var result = new List<AvailableBookLookupModel>();

            var dbHelper = new DbHelper(_readDBConnectionStringProvider.ConnectionString);
            var dataTable = dbHelper.ExecuteDataTable("SELECT b.BookId, b.BookName FROM Book b INNER JOIN BookInventory br ON b.BookId = br.BookId WHERE br.Status = 1 GROUP BY b.BookId, b.BookName HAVING COUNT(br.BookInventoryId) > 0");

            foreach (var item in dataTable.Rows.Cast<DataRow>())
            {
                result.Add(new AvailableBookLookupModel
                {
                    BookId = Guid.Parse(item["BookId"].ToString()),
                    Name = item["BookName"].ToString()
                });
            }

            return result;
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

                var InventoryDatas = dbHelper.ExecuteDataTable(@"
                    SELECT *, (SELECT TOP 1 h.Note From History h Where h.BookInventoryId = br.BookInventoryId) as LastNote FROM BookInventory br WHERE br.BookId = @bookId
                    ", new SqlParameter { ParameterName = "@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId });

                var repositories = InventoryDatas.ConvertToBookInventoryViewModel();

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

        public void AddBookInventory(Guid bookId, Guid bookInventoryId, BookInventoryStatus status, string notes)
        {
            _commands.Add(new Command("INSERT INTO BookInventory(BookInventoryId, BookId, Status, IsRemoved) VALUES(@bookInventoryId, @bookId, @status, @isRemoved)", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookInventoryId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookInventoryId },
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@status", SqlDbType = SqlDbType.Int, Value = Convert.ToInt32(status) },
                new SqlParameter{ ParameterName ="@isRemoved", SqlDbType = SqlDbType.Bit, Value = false }
                }));

            _commands.Add(new Command("INSERT INTO History(HistoryId, BookInventoryId, BookId, Note, CreatedOn) values(@historyId, @bookInventoryId, @bookId, @note, @createdOn)", new List<SqlParameter>{
                new SqlParameter{ ParameterName ="@bookInventoryId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookInventoryId },
                new SqlParameter{ ParameterName ="@bookId", SqlDbType = SqlDbType.UniqueIdentifier, Value = bookId },
                new SqlParameter{ ParameterName ="@historyId", SqlDbType = SqlDbType.UniqueIdentifier, Value = Guid.NewGuid() },
                new SqlParameter{ ParameterName ="@createdOn", SqlDbType = SqlDbType.DateTime2, Value = DateTime.Now },
                new SqlParameter{ ParameterName ="@note", SqlDbType = SqlDbType.NVarChar, Value = notes }
                }));
        }
    }
}
