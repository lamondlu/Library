using Library.Domain.Core;
using Library.Domain.Core.Messaging;
using Library.Infrastructure.InjectionFramework;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
			var result = new List<DomainEvent>();

			using (_dbContext)
			{
				var root = _dbContext.Collection<AggregateRoot>().Find(p => p.AggregateRootId == aggregateId).FirstOrDefault();

				if (root != null)
				{
					JsonSerializerSettings setting = new JsonSerializerSettings();
					setting.MaxDepth = 10;

					foreach (var item in root.Events)
					{
						var type = Assembly.Load(item.AssemblyName).GetType(item.EventName);
						var c_item = (DomainEvent)JsonConvert.DeserializeObject(item.Content, type, setting);
						result.Add(c_item);
					}
				}

				return result;
			}
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

						var root = _dbContext.Collection<AggregateRoot>().Find(p => p.AggregateRootId == aggregate.Id).FirstOrDefault();

						if (root == null)
						{
							_dbContext.Collection<AggregateRoot>().InsertOne(new AggregateRoot
							{
								AggregateRootId = aggregate.Id,
								Version = 1,
								Events = new List<EventObject>
								{
									new EventObject
									{
										EventName = @event.GetType().FullName,
										AssemblyName = @event.GetType().Assembly.GetName().Name,
										Content = JsonConvert.SerializeObject(@event),
										OccurredOn = @event.OccurredOn,
										Version = @event.Version
									}
								}
							});
						}
						else
						{
							var filter = Builders<AggregateRoot>.Filter.Eq(e => e.AggregateRootId, aggregate.Id);
							var update = Builders<AggregateRoot>.Update.Push<EventObject>(e => e.Events, new EventObject
							{
								EventName = @event.GetType().FullName,
								AssemblyName = @event.GetType().Assembly.GetName().Name,
								Content = JsonConvert.SerializeObject(@event),
								OccurredOn = @event.OccurredOn,
								Version = @event.Version
							});

							var updateVersion = Builders<AggregateRoot>.Update.Set<int>(e => e.Version, @event.Version);

							_dbContext.Collection<AggregateRoot>().UpdateOne(filter, update);
							_dbContext.Collection<AggregateRoot>().UpdateOne(filter, updateVersion);
						}

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