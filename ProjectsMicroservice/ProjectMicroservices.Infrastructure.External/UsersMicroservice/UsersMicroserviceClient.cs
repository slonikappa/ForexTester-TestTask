using ProjectMicroservices.Infrastructure.External.UsersMicroservice.Enums;
using ProjectMicroservices.Infrastructure.External.UsersMicroservice.Models;

using RestEase;

namespace ProjectMicroservices.Infrastructure.External.UsersMicroservice;

public class UsersMicroserviceClient : IUsersMicroservice
{
    private readonly IUsersMicroservice _client;
    public UsersMicroserviceClient()
    {
        // TODO: Move microservice address to config
        _client = RestClient.For<IUsersMicroservice>("http://usersmicroservice/");
    }

    public async Task<IEnumerable<User>> GetAllBySubscriptionType(SubscriptionType subscriptionType)
        => await _client.GetAllBySubscriptionType(subscriptionType);
}
