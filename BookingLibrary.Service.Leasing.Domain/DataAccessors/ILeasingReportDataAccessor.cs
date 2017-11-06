using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Leasing.Domain.ViewModels;

namespace BookingLibrary.Service.Leasing.Domain.DataAccessors
{
    public interface ILeasingReportDataAccessor
    {
        List<UnreturnedBookViewModel> GetUnreturnBooks();

        bool IsNewCustomer(Guid customerId);

        void RentBook(Guid bookId, string bookName, string isbn, Guid customerId, PersonName name, DateTime rentDate);

        void ReturnBook(Guid bookId, DateTime returnDate);

        void Commit();

        Task CommitAsync();
    }
}