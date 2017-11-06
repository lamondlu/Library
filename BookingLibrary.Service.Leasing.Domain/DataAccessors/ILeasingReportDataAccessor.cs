using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Repository.Domain.DataAccessors
{
    public interface ILeasingReportDataAccessor
    {
        bool IsNewCustomer(Guid customerId);

        void AddRentedBookRecord(Guid bookId, string bookName, string isbn, Guid customerId, PersonName name, DateTime rentDate);

        void Commit();

        Task CommitAsync();
    }
}