using Library.Domain.Core.DataAccessor;

namespace Library.Service.Identity.Domain.DataAccessors
{
    public interface IIdentityReadDBConnectionStringProvider : IReadConnectionStringProvider
    {
    }

    public interface IIdentityWriteDBConnectionStringProvider : IWriteConnectionStringProvider
    {
    }
}