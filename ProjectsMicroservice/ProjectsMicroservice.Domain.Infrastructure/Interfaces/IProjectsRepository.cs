
using ProjectsMicroservice.Domain.Core.Entities;
using ProjectsMicroservice.Domain.Infrastructure.Models;

namespace ProjectsMicroservice.Domain.Infrastructure.Interfaces;

public interface IProjectsRepository : IRepository<Project>
{
    List<IndicatorCount> GetIndicatorsByMultipleUserId(int[] userIds);
}
