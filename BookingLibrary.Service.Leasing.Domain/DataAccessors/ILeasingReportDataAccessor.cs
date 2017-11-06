using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.DataAccessors
{
    public interface ILeasingReportDataAccessor
    {
        bool IsNewCustomer(Guid customerId);

        void RentBook(Guid bookId, string bookName, string isbn, Guid customerId, PersonName name, DateTime rentDate);

        void ReturnBook(Guid bookId, DateTime returnDate);

        void Commit();

        Task CommitAsync();
    }
}