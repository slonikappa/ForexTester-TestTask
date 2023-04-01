using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Core.Enums;

namespace UserMicroservice.Domain.Infastructure.Interfaces;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User> GetById(int id);
    Task<List<User>> GetAllWithSubscriptions();
    Task<List<User>> GetUsersBySubscriptionType(SubscriptionType subscriptionType);
}
