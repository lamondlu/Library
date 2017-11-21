using System;

namespace Library.Infrastructure.Messaging.RabbitMQ
{
    public interface IRabbitMQUrlProvider
    {
        string Url
        {
            get;
        }
    }
}