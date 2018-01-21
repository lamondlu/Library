namespace Library.Infrastructure.Operation.Consul
{
	public interface IConsulAPIUrlProvider
	{
		string Url { get; }
	}
}