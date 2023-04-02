
using UserMicroservice.Application.Models;
using UserMicroservice.Domain.Core.Entities;

namespace UserMicroservice.Application.Mappers;

public class ApplicationMapper : IApplicationMapper
{
    public User UpdateModelToUser(User user, UpdateUserRequestModel model)
    {
        user.Email = model.Email;
        user.Name = model.Name;

        return user;
    }

    public User AddModelToUserWithSubscription(AddUserRequestModel model)
        => new()
        {
            Name = model.Name,
            Email = model.Email,
            Subscription = new Subscription
            {
                Type = model.SubscriptionType,
                startDate = DateTime.Now,
                endDate = DateTime.Now.AddDays(60),
            },
        };
}
