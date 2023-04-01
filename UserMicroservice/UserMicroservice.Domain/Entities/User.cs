using UserMicroservice.Domain.Core.Interfaces;

namespace UserMicroservice.Domain.Core.Entities;

public class User : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int SubscriptionId { get; set; }

    public Subscription Subscription { get; set; } = null!;
}
