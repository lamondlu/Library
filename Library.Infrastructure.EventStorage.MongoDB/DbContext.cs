using Library.Domain.Core.DataAccessor;
using Library.Infrastructure.InjectionFramework;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.EventStorage.MongoDB
{
    public class DbContext : IDisposable
    {
        private IMongoDatabase _db;

        public DbContext()
        {
            var conn = InjectContainer.GetInstance<IEventDBConnectionStringProvider>().ConnectionString;
            var client = new MongoClient(conn);

            
            _db = client.GetDatabase("LibraryEventStorage");
        }

        public IMongoCollection<T> Collection<T>() where T : Entity
        {
            var collectionName = InferCollectionNameFrom<T>();
            return _db.GetCollection<T>(collectionName);
        }

        private static string InferCollectionNameFrom<T>()
        {
            var type = typeof(T);
            return type.Name;
        }

        public void Dispose()
        {
            
        }
    }
}
