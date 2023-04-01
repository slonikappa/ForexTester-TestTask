using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using ProjectsMicroservice.Domain.Core.Enums;
using ProjectsMicroservice.Domain.Core.Interfaces;

namespace ProjectsMicroservice.Domain.Core.Models;

internal class UserSettings : IEntity
{
    public ObjectId Id { get; set; }

    [BsonRepresentation(BsonType.String)]
    public Language Language { get; set; }

    [BsonRepresentation(BsonType.String)]
    public ThemeStyle Theme { get; set; }
}
