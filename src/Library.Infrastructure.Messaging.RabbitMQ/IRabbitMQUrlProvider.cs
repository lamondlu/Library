namespace Library.Infrastructure.Messaging.RabbitMQ
{
	public interface IRabbitMQUrlProvider
	{
		string Url
		{
			get;
		}

		string UserName { get; }

		string Password { get; }
	}
}