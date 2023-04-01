using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using ProjectsMicroservice.Domain.Core.Interfaces;

namespace ProjectsMicroservice.Domain.Core.Models;

public class Project : IEntity
{
    [BsonId]
    public ObjectId Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Chart> Charts { get; set; } = new();
}
