using Library.Domain.Core;
using Library.Domain.Core.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Library.Infrastructure.Messaging.RabbitMQ
{
	public class RabbitMQEventPublisher : IEventPublisher
	{
		private readonly IConnection connection;
		private readonly IModel channel;

		public RabbitMQEventPublisher(IRabbitMQUrlProvider provider)
		{
			var factory = new ConnectionFactory() { Uri = new Uri(provider.Url), UserName = provider.UserName, Password = provider.Password };
			this.connection = factory.CreateConnection();
			this.channel = connection.CreateModel();
		}

		public void Dispose()
		{
			this.channel.Dispose();
			this.connection.Dispose();
		}

		public void Publish<T>(T domainEvent) where T : DomainEvent
		{
			var json = JsonConvert.SerializeObject(domainEvent, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
			var bytes = Encoding.UTF8.GetBytes(json);

			var properties = channel.CreateBasicProperties();
			properties.Persistent = true;
			channel.BasicPublish(exchange: "", routingKey: domainEvent.EventKey, basicProperties: properties, body: bytes);
		}
	}
}