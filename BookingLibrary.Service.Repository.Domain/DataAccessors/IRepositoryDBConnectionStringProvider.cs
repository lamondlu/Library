using System;
using BookingLibrary.Domain.Core.DataAccessor;

namespace BookingLibrary.Service.Repository.Domain.DataAccessors
{
    public interface IRepositoryReadDBConnectionStringProvider : IReadConnectionStringProvider
    {

    }

    public interface IRepositoryWriteDBConnectionStringProvider : IWriteConnectionStringProvider
    {

    }
}