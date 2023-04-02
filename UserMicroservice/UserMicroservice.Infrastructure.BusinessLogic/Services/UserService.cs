using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Core.Enums;
using UserMicroservice.Domain.Infastructure.Interfaces;

namespace UserMicroservice.Infrastructure.BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddUserWithSubscription(User user)
    {
        await _unitOfWork.SaveChanges(() =>
        {
            _unitOfWork.UsersRepository.Add(user);
        });
    }

    public async Task<List<User>> GetUsers()
    {
        return await _unitOfWork.UsersRepository.GetAll();
    }

    public async Task<User> GetById(int id) => await _unitOfWork.UsersRepository.GetItem(id);

    public async Task<IEnumerable<User>> GetUsersBySubscriptionType(SubscriptionType subscriptionType)
        => await _unitOfWork.UsersRepository.GetAllBySubscriptionType(subscriptionType);

    public Task<List<User>> GetAllWithSubscriptions()
    {
        return _unitOfWork.UsersRepository.GetAllWithSubscriptions();
    }

    public async Task UpdateUser(User userToUpdate)
    {
        await _unitOfWork.SaveChanges(() =>
        {
            _unitOfWork.UsersRepository.Update(userToUpdate);
        });
    }

    public async Task RemoveUser(User user)
    {
        await _unitOfWork.SaveChanges(() =>
        {
            _unitOfWork.UsersRepository.DeleteByItem(user);
        });
    }
}
