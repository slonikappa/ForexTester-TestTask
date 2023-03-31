using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Core.Enums;

namespace UserMicroservice.Domain.Infastructure.Interfaces;

public interface IUserService
{
    List<User> GetUsers();
    List<User> GetUsersBySubscriptionType(SubscriptionType subscriptionType);
}
