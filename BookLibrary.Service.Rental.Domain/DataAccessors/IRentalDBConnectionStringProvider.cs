using System;
using BookLibrary.Domain.Core.DataAccessor;

namespace BookLibrary.Service.Rental.Domain.DataAccessors
{
    public interface IRentalReadDBConnectionStringProvider : IReadConnectionStringProvider
    {

    }

    public interface IRentalWriteDBConnectionStringProvider : IWriteConnectionStringProvider
    {

    }
}