using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.EventStorage.MongoDB
{
    public abstract class Entity : EntityWithTypedId<ObjectId>
    {

    }

    public abstract class EntityWithTypedId<TId>
    {
        public TId Id { get; set; }
    }
}
