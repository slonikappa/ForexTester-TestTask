using UserMicroservice.Domain.Core.Enums;
using UserMicroservice.Domain.Core.Interfaces;

namespace UserMicroservice.Domain.Core.Entities;

public class Subscription : IEntity
{
    public int Id { get; set; }
    public SubscriptionType Type { get; set; }
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public User User { get; set; } = null!;
}
