using System;
using BookingLibrary.Domain.Core.Messaging;

namespace BookingLibrary.Infrastructure.Messaging.RabbitMQ
{
    public class RabbitMQCommandPublisher : ICommandPublisher
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Publish<ICommand>(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
