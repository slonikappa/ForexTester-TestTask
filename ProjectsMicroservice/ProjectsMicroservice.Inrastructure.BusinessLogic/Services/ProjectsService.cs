using ProjectMicroservices.Infrastructure.External.UsersMicroservice;
using ProjectMicroservices.Infrastructure.External.UsersMicroservice.Enums;

using ProjectsMicroservice.Domain.Core.Entities;
using ProjectsMicroservice.Domain.Infrastructure.Interfaces;
using ProjectsMicroservice.Domain.Infrastructure.Models;

namespace ProjectsMicroservice.Inrastructure.BusinessLogic.Services;

public class ProjectsService : IProjectsService
{
    private readonly IProjectsRepository _projectsRepository;
    private readonly IUsersMicroservice _usersMicroserviceClient;

    public ProjectsService(IProjectsRepository projectsRepository,
        IUsersMicroservice usersMicroserviceClient)
    {
        _projectsRepository = projectsRepository;
        _usersMicroserviceClient = usersMicroserviceClient;
    }

    public async Task AddProject(Project project)
    {
       await _projectsRepository.Create(project);
    }

    public async Task DeleteProject(int userId)
    {
       await _projectsRepository.Delete(userId);
    }

    public async Task<Project> GetProjectByUserId(int usedId)
    {
        return await _projectsRepository.GetById(usedId);
    }

    public async Task<IEnumerable<Project>> GetProjectList()
    {
        return await _projectsRepository.GetAll();
    }

    public async Task UpdateProject(Project project)
    {
        await _projectsRepository.Update(project);
    }

    public async Task<List<IndicatorCount>> GetMostUsedProjectIndicatorsBySubsType(SubscriptionType type)
    {
        var superUsers = await _usersMicroserviceClient.GetAllBySubscriptionType(type);

        return _projectsRepository.GetIndicatorsByMultipleUserId(superUsers.Select(x => x.Id).ToArray());
    }
}
