using System;
using BookingLibrary.Domain.Core.DataAccessor;

namespace BookingLibrary.Service.Leasing.Domain.DataAccessors
{
    public interface ILeasingReadDBConnectionStringProvider : IReadConnectionStringProvider
    {

    }

    public interface ILeasingWriteDBConnectionStringProvider : IWriteConnectionStringProvider
    {

    }
}