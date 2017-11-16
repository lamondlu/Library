using System;
using BookLibrary.Domain.Core.DataAccessor;

namespace BookLibrary.Service.Identity.Domain.DataAccessors
{
    public interface IIdentityReadDBConnectionStringProvider : IReadConnectionStringProvider
    {

    }

    public interface IIdentityWriteDBConnectionStringProvider : IWriteConnectionStringProvider
    {

    }
}