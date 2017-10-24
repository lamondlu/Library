using System;
using BookingLibrary.Service.Identity.Domain.ViewModels;

namespace BookingLibrary.Service.Identity.Domain.DataAccessors
{
    public interface IIdentityReportDataAccessor
    {
        IdentityViewModel GetIdentity(string userName, string hashedPassword);
    }
}