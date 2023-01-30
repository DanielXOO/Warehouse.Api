using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Warehouse.Data.Entities.Generators;

public class LongIdGenerator : IIdGenerator
{
    public object GenerateId(object container, object document)
    {
        var containerDynamic = (dynamic)container;
        var idSequenceCollection = containerDynamic.Database.GetCollection<dynamic>("Counters");

        var filter = Builders<dynamic>.Filter.Eq("_id", containerDynamic.CollectionNamespace.CollectionName);
        var update = Builders<dynamic>.Update.Inc("Seq", 1L);

        var options = new FindOneAndUpdateOptions<dynamic>
        {
            IsUpsert = true,
            ReturnDocument = ReturnDocument.After
        };

        return idSequenceCollection.FindOneAndUpdate(filter, update, options).Seq;
    }

    public bool IsEmpty(object id)
    {
        return id is long && id as long? == 0;
    }
}