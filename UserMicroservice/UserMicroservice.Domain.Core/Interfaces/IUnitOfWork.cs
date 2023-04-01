using UserMicroservice.Domain.Core.Entities;

namespace UserMicroservice.Domain.Infastructure.Interfaces;

public interface IUnitOfWork
{
    IUsersRepository UsersRepository { get; }
    IRepository<Subscription> SubscriptionRepository { get; }

    Task<bool> SaveChanges(Action func);
}
