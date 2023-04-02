using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Core.Enums;

namespace UserMicroservice.Domain.Infastructure.Interfaces;

public interface IUserService
{
    Task AddUserWithSubscription(User user);
    Task<List<User>> GetUsers();
    Task<User> GetById(int id);
    Task<List<User>> GetAllWithSubscriptions();
    Task<IEnumerable<User>> GetUsersBySubscriptionType(SubscriptionType subscriptionType);
    Task UpdateUser(User user);
    Task RemoveUser(User user);
}
