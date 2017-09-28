using System;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Service.Identity.Domain
{
    public interface IIdentityReportDataAccessor 
    {
        void AddUser(User user);

        void AddAdministrator(Administrator administrator);
    }
}