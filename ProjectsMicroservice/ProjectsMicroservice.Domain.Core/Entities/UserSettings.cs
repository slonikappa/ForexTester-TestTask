using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using ProjectsMicroservice.Domain.Core.Enums;
using ProjectsMicroservice.Domain.Core.Interfaces;

namespace ProjectsMicroservice.Domain.Core.Entities;

public class UserSettings : IEntity
{
    [BsonId]
    public ObjectId Id { get; set; }
    public int UserId { get; set; }

    [BsonRepresentation(BsonType.String)]
    public Language Language { get; set; }

    [BsonRepresentation(BsonType.String)]
    public ThemeStyle Theme { get; set; }
}
