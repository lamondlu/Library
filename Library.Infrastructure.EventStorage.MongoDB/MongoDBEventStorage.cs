using Library.Domain.Core;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.InjectionFramework;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.EventStorage.MongoDB
{
    public class MongoDBEventStorage : IEventStorage
    {
        private DbContext _dbContext;
        private readonly IEventPublisher _eventPublisher = null;

        public MongoDBEventStorage()
        {
            _dbContext = new DbContext();
            _eventPublisher = InjectContainer.GetInstance<IEventPublisher>();
        }

        public IEnumerable<DomainEvent> GetEvents(Guid aggregateId)
        {
            throw new NotImplementedException();
            //using (_dbContext)
            //{
            //    var collection = _dbContext.Collection<EventObject>().FindAsync().Result;
            //}
        }

        public void Save(Domain.Core.AggregateRoot aggregate, Guid commandUniqueId)
        {
            using (_dbContext)
            {
                var uncommittedChanges = aggregate.GetUncommittedChanges();
                var currentIndex = 0;

                try
                {
                    var version = aggregate.Version;

                    foreach (var @event in uncommittedChanges)
                    {
                        version++;
                        @event.Version = version;
                        @event.CommandUniqueId = commandUniqueId;

                        //var filter = Builders<AggregateRoot>.Filter.Eq<Guid>((a, b)=> {

                        //}, aggregate.Id);

                        //_dbContext.Collection<AggregateRoot>().FindOneAndUpdateAsync();

                        //_dbContext.Collection<AggregateRoot>().InsertOne(new EventObject
                        //{
                        //    AggregateRootId = aggregate.Id,
                        //    EventName = @event.GetType().FullName,
                        //    AssemblyName = @event.GetType().Assembly.GetName().Name,
                        //    Content = JsonConvert.SerializeObject(@event),
                        //    OccurredOn = @event.OccurredOn,
                        //    Version = @event.Version
                        //});

                        currentIndex++;
                    }

                    foreach (var @event in uncommittedChanges)
                    {
                        var desEvent = Converter.ChangeTo(@event, @event.GetType());
                        _eventPublisher.Publish(desEvent);
                    }
                }
                catch
                {
                }
            }
        }
    }
}
