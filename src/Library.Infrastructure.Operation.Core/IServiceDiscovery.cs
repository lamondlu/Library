using Library.Infrastructure.Operation.Core.Models;

namespace Library.Infrastructure.Operation.Core
{
	public interface IServiceDiscovery
	{
		void RegisterService(Service service);
	}
}