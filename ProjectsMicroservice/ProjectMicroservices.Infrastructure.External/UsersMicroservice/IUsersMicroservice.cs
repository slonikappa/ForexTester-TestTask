using ProjectMicroservices.Infrastructure.External.UsersMicroservice.Enums;
using ProjectMicroservices.Infrastructure.External.UsersMicroservice.Models;

using RestEase;

namespace ProjectMicroservices.Infrastructure.External.UsersMicroservice;

public interface IUsersMicroservice
{
    [Get("/api/user/all-by-subscription/{subscriptionType}")]
    Task<IEnumerable<User>> GetAllBySubscriptionType([Path] SubscriptionType subscriptionType);
}
