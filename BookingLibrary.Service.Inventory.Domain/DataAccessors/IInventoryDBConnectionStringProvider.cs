using System;
using BookingLibrary.Domain.Core.DataAccessor;

namespace BookingLibrary.Service.Inventory.Domain.DataAccessors
{
    public interface IInventoryReadDBConnectionStringProvider : IReadConnectionStringProvider
    {

    }

    public interface IInventoryWriteDBConnectionStringProvider : IWriteConnectionStringProvider
    {

    }
}