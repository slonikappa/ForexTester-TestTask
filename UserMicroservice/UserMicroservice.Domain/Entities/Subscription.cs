using UserMicroservice.Domain.Core.Enums;
using UserMicroservice.Domain.Core.Interfaces;

namespace UserMicroservice.Domain.Core.Entities;

internal class Subscription : IEntity
{
    public int Id { get; set; }
    public SubsciptionType Type { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
}
