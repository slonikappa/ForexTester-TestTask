using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Core.Enums;

namespace UserMicroservice.Domain.Infastructure.Interfaces;

public interface IUsersRepository : IRepository<User>
{
    Task<List<User>> GetAllWithSubscriptions();
    Task<IEnumerable<User>> GetAllBySubscriptionType(SubscriptionType subscriptionType);
}
