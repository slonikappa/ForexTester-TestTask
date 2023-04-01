using UserMicroservice.Domain.Core.Entities;

namespace UserMicroservice.Domain.Infastructure.Interfaces;

public interface IUsersRepository : IRepository<User>
{
    Task<List<User>> GetAllWithSubscriptions();
}
