using ProjectMicroservices.Infrastructure.External.UsersMicroservice.Enums;

using ProjectsMicroservice.Domain.Core.Entities;
using ProjectsMicroservice.Domain.Infrastructure.Models;

namespace ProjectsMicroservice.Domain.Infrastructure.Interfaces;

public interface IProjectsService
{
    Task AddProject(Project project);
    Task UpdateProject(Project project);
    Task DeleteProject(int userId);
    Task<IEnumerable<Project>> GetProjectList();
    Task<Project> GetProjectByUserId(int usedId);
    Task<List<IndicatorCount>> GetMostUsedProjectIndicatorsBySubsType(SubscriptionType type);
}
