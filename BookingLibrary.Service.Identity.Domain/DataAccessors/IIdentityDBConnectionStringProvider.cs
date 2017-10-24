using System;
using BookingLibrary.Domain.Core.DataAccessor;

namespace BookingLibrary.Service.Identity.Domain.DataAccessors
{
    public interface IIdentityReadDBConnectionStringProvider : IReadConnectionStringProvider
    {

    }

    public interface IIdentityWriteDBConnectionStringProvider : IWriteConnectionStringProvider
    {

    }
}