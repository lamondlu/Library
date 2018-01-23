using Library.Domain.Core.DataAccessor;

namespace Library.Service.Inventory.Domain.DataAccessors
{
	public interface IInventoryReadDBConnectionStringProvider : IReadConnectionStringProvider
	{
	}

	public interface IInventoryWriteDBConnectionStringProvider : IWriteConnectionStringProvider
	{
	}
}