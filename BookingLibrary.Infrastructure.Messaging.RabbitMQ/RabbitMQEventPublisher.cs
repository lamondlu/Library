using System;
using BookingLibrary.Domain.Core.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using BookingLibrary.Domain.Core;

namespace BookingLibrary.Infrastructure.Messaging.RabbitMQ
{
    public class RabbitMQEventPublisher : IEventPublisher
    {

        private readonly IConnection connection;
        private readonly IModel channel;

        public RabbitMQEventPublisher(string uri)
        {
            var factory = new ConnectionFactory() { Uri = new Uri(uri) };
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
            channel.BasicPublish(exchange: "", routingKey: domainEvent.GetType().Name, basicProperties: properties, body: bytes);
        }
    }
}
