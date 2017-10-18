using System;
using System.Text;
using BookingLibrary.Domain.Core.Messaging;
using BookingLibrary.Domain.Core.Commands;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection;
using System.Linq;

namespace BookingLibrary.Infrastructure.Messaging.RabbitMQ
{
    public class RabbitMQCommandSubscriber : ICommandSubscriber
    {
        private readonly IConnection connection;
        private readonly IModel channel;

        public RabbitMQCommandSubscriber(string uri)
        {
            var factory = new ConnectionFactory() { Uri = new Uri(uri) };
            this.connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
        }

        public void Subscribe<T>(T command) where T : ICommand
        {
            this.channel.QueueDeclare(queue: command.CommandKey,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            var consumer = new EventingBasicConsumer(channel);

            Func<Type, bool> isCommandHandler = i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>) && i.GenericTypeArguments.Any(x => x == typeof(T));

            var handlerType = typeof(T).Assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(isCommandHandler)).FirstOrDefault();


            ICommandHandler<T> instance = null;
            if (handlerType != null)
            {
                instance = (ICommandHandler<T>)Activator.CreateInstance(handlerType, new object[1] { null });
            }
            else
            {
                throw new Exception($"The command handler for {typeof(T).FullName} is not prepared.");
            }



            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("[x] Received {0}", message);

                var cmd = (T)JsonConvert.DeserializeObject(message);

                //执行命令操作
                instance.Execute(cmd);

                channel.BasicAck(ea.DeliveryTag, false);
            };

            channel.BasicConsume(queue: command.CommandKey, autoAck: false, consumer: consumer);
        }

        public void Dispose()
        {
            this.channel.Dispose();
            this.connection.Dispose();
        }
    }
}
