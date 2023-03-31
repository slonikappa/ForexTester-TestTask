using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Core.Enums;
using UserMicroservice.Domain.Infastructure.Interfaces;

namespace UserMicroservice.Infrastructure.BusinessLogic.Services;

public class UserService : IUserService
{
    public List<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public List<User> GetUsersBySubscriptionType(SubscriptionType subscriptionType)
    {
        throw new NotImplementedException();
    }
}
