using Library.Domain.Core.Commands;
using Library.Domain.Core.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Library.Infrastructure.Messaging.RabbitMQ
{
    public class RabbitMQCommandPublisher : ICommandPublisher
    {
        private readonly IConnection connection;
        private readonly IModel channel;

        public RabbitMQCommandPublisher(IRabbitMQUrlProvider provider)
        {
            var factory = new ConnectionFactory() { Uri = new Uri(provider.Url) };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
        }

        public void Dispose()
        {
            this.channel.Dispose();
            this.connection.Dispose();
        }

        public void Publish<T>(T command) where T : ICommand
        {
            var json = JsonConvert.SerializeObject(command, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            var bytes = Encoding.UTF8.GetBytes(json);

            this.channel.QueueDeclare(queue: command.CommandKey,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            channel.BasicPublish(exchange: "", routingKey: command.CommandKey, basicProperties: properties, body: bytes);
        }
    }
}