using System.Text.Json.Serialization;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using ProjectsMicroservice.Domain.Core.Interfaces;

namespace ProjectsMicroservice.Domain.Core.Entities;

public class Project : IEntity
{
    [BsonId]
    [JsonIgnore]
    public ObjectId Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Chart> Charts { get; set; } = new();
}
