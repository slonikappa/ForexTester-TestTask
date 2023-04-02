using UserMicroservice.Application.Models;
using UserMicroservice.Domain.Core.Entities;

namespace UserMicroservice.Application.Mappers;


/// <summary>
/// Mapper for API models <--> entities. Should be changed to use AutoMapper
/// </summary>
public interface IApplicationMapper
{
    User AddModelToUserWithSubscription(AddUserRequestModel model);
    User UpdateModelToUser(User user, UpdateUserRequestModel model);
}
