using System;
using BookLibrary.Domain.Core.DataAccessor;

namespace BookLibrary.Service.Inventory.Domain.DataAccessors
{
    public interface IInventoryReadDBConnectionStringProvider : IReadConnectionStringProvider
    {

    }

    public interface IInventoryWriteDBConnectionStringProvider : IWriteConnectionStringProvider
    {

    }
}