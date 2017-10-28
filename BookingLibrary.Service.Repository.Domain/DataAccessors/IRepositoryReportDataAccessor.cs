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
        void AddBookRepository(AddBookDTO dto);

        List<BookViewModel> GetBookRepositories();

        BookDetailedModel GetBookById(Guid bookId);

        bool ExistISBN(string isbn, Guid? bookId = null);

        void UpdateBookName(Guid bookId, string bookName);

        void UpdateBookDescription(Guid bookId,string description);

        void UpdateBookISBN(Guid bookId, string isbn);

        void UpdateBookIssuedDate(Guid bookId, DateTime issuedDate);

        void UpdateBookStatus(Guid bookId, BookStatus status);

        void DeleteBookRepository(Guid bookRepositoryId);

        void Commit();

        Task CommitAsync();
    }
}