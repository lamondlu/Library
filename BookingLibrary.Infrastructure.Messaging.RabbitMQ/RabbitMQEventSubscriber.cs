using System;
using System.Text;
using BookingLibrary.Domain.Core.Messaging;
using BookingLibrary.Domain.Core.Commands;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace BookingLibrary.Infrastructure.Messaging.RabbitMQ
{
    public class RabbitMQCommandSubscriber : ICommandSubscriber
    {
        private readonly IConnection connection;
        private readonly IModel channel;

        public RabbitMQCommandSubscriber(string uri)
        {

        }

        public void Subscribe<T>(T command) where T : ICommand
        {

        }

        public void Dispose()
        {

        }
    }
}
