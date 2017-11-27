using Library.Domain.Core.Commands;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.InjectionFramework;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Library.Infrastructure.Messaging.RabbitMQ
{
    public class RabbitMQCommandSubscriber : ICommandSubscriber
    {
        private readonly IConnection connection;
        private readonly IModel channel;

        public RabbitMQCommandSubscriber(IRabbitMQUrlProvider provider)
        {
            var factory = new ConnectionFactory() { Uri = new Uri(provider.Url), UserName = provider.UserName, Password = provider.Password };
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

            ICommandHandler<T> instance = InjectContainer.GetInstance<ICommandHandler<T>>();
            if (instance == null)
            {
                Console.WriteLine($"The command handler for {typeof(T).FullName} is not prepared.");
            }

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);

                var cmd = JsonConvert.DeserializeObject<T>(message);
                Console.WriteLine("[x] Receive New Task: {0}", cmd.CommandKey);
                Console.WriteLine("[x] Task Parameters: {0}", message);

                //执行命令操作
                instance.Execute(cmd);

                Console.WriteLine("[x] Task Completed");

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