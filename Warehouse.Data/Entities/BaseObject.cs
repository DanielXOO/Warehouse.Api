using MongoDB.Bson.Serialization.Attributes;
using Warehouse.Data.Entities.Generators;

namespace Warehouse.Data.Entities;

public abstract class BaseObject
{
    [BsonId(IdGenerator = typeof(LongIdGenerator))]
    public long Id { get; set; }
}