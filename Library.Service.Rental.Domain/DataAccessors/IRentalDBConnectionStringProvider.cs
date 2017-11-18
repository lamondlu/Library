using Library.Domain.Core.DataAccessor;

namespace Library.Service.Rental.Domain.DataAccessors
{
    public interface IRentalReadDBConnectionStringProvider : IReadConnectionStringProvider
    {
    }

    public interface IRentalWriteDBConnectionStringProvider : IWriteConnectionStringProvider
    {
    }
}