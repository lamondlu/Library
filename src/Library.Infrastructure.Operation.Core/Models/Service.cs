namespace Library.Infrastructure.Operation.Core.Models
{
	public class Service
	{
		public string ServiceUniqueId { get; set; }

		public string ServiceName { get; set; }

		public string Tag { get; set; }

		public int Port { get; set; }

		public string Address { get; set; }
	}
}