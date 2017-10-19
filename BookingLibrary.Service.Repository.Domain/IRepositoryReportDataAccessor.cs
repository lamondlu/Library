using System;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Repository.Domain.DTOs;

namespace BookingLibrary.Service.Repository.Domain
{
    public interface IRepositoryReportDataAccessor 
    {
        void AddBookRepository(AddBookDTO dto);
    }
}