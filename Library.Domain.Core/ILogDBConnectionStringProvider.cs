namespace Library.Domain.Core
{
	public interface ILogDBConnectionStringProvider
	{
		string ConnectionString { get; }
	}
}