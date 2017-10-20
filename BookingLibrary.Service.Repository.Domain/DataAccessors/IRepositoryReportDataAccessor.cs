using System;
using System.Collections.Generic;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DTOs;
using BookingLibrary.Service.Repository.Domain.ViewModels;

namespace BookingLibrary.Service.Repository.Domain.DataAccessors
{
    public interface IRepositoryReportDataAccessor
    {
        void AddBookRepository(AddBookDTO dto);

        List<BookViewModel> GetBookRepositories();
    }
}