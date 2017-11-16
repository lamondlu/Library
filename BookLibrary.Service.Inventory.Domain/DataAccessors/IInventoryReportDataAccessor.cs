using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookLibrary.Domain.Core;
using BookLibrary.Service.Inventory.Domain.DTOs;
using BookLibrary.Service.Inventory.Domain.ViewModels;

namespace BookLibrary.Service.Inventory.Domain.DataAccessors
{
    public interface IInventoryReportDataAccessor
    {
        List<AvailableBookLookupModel> GetAvailableBooks();

        void AddBook(AddBookDTO dto);

        List<BookViewModel> GetBooks();

        BookDetailedModel GetBookById(Guid bookId);

        bool ExistISBN(string isbn, Guid? bookId = null);

        void UpdateBookName(Guid bookId, string bookName);

        void UpdateBookDescription(Guid bookId,string description);

        void UpdateBookISBN(Guid bookId, string isbn);

        void UpdateBookIssuedDate(Guid bookId, DateTime issuedDate);

        void UpdateBookInventoryStatus(Guid bookInventoryId, BookInventoryStatus status, string notes);

        void AddBookInventory(Guid bookId, Guid bookInventoryId, BookInventoryStatus status, string notes);

        void RemoveBookInventory(Guid bookInventoryId);

        void DeleteBook(Guid bookId);

        void Commit();

        Task CommitAsync();
    }
}