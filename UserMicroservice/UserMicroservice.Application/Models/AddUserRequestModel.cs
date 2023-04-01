using UserMicroservice.Domain.Core.Enums;

namespace UserMicroservice.Application.Models;

public class AddUserRequestModel
{
    public string Name { get; set;} = string.Empty;
    public string Email { get; set; } = string.Empty;
    public SubscriptionType SubscriptionType { get; set; }
}
