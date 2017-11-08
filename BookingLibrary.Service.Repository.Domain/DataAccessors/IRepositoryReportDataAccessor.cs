using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.ViewModels;

namespace BookingLibrary.Service.Repository.Domain.DataAccessors
{
    public interface IRepositoryReportDataAccessor
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

        void UpdateBookRepositoryStatus(Guid bookRepositoryId, BookRepositoryStatus status, string notes);

        void ImportBookRepositoies(Guid bookId, List<BookRepository> bookRepositories);

        void RemoveBookRepository(Guid bookRepositoryId);

        void DeleteBook(Guid bookId);

        void Commit();

        Task CommitAsync();
    }
}