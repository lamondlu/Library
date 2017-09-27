using System;

namespace BookingLibrary.Domain.Core.DataAccessor
{
    public interface IWriteConnectionStringProvider
    {
        string ConnectionString { get; }
    }

    public interface IReadConnectionStringProvider
    {
        string ConnectionString { get; }
    }

    public interface IEventDBConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}
