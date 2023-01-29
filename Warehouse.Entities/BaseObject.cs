using MongoDB.Bson.Serialization.Attributes;

namespace Warehouse.Entities;

public abstract class BaseObject
{
    [BsonId]
    public long Id { get; set; }
}