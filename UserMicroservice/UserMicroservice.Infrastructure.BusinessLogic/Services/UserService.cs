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

    public void AddUserWithSubscription(User user)
    {
        _unitOfWork.SaveChanges(() =>
        {
            _unitOfWork.UsersRepository.Add(user);
        });
    }

    public async Task<List<User>> GetUsers()
    {
        return await _unitOfWork.UsersRepository.GetAll();
    }

    public async Task<User> GetById(int id) => await _unitOfWork.UsersRepository.GetItem(id);

    public Task<List<User>> GetUsersBySubscriptionType(SubscriptionType subscriptionType)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllWithSubscriptions()
    {
        return _unitOfWork.UsersRepository.GetAllWithSubscriptions();
    }
}
