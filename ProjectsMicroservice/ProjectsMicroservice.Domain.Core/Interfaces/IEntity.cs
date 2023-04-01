using MongoDB.Bson;

namespace ProjectsMicroservice.Domain.Core.Interfaces;

internal interface IEntity
{
    public ObjectId Id { get; set; }
}
