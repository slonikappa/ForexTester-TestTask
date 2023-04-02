using Microsoft.Extensions.Options;

using MongoDB.Driver;

using ProjectsMicroservice.Domain.Core.Entities;
using ProjectsMicroservice.Domain.Core.Options;
using ProjectsMicroservice.Domain.Infrastructure.Interfaces;
using ProjectsMicroservice.Domain.Infrastructure.Models;

namespace ProjectsMicroservice.Infrastructure.DataAccess.Repositories;

public class ProjectsRepository : IProjectsRepository
{
    private readonly IMongoCollection<Project> _projects;

    public ProjectsRepository(IMongoClient mongoClient, IOptions<MongoDbOptions> mongoDbOptions)
    {
        if (string.IsNullOrWhiteSpace(mongoDbOptions.Value.DatabaseName))
        {
            throw new ArgumentException("Database name cannot be null or whitespace.", nameof(mongoDbOptions));
        }

        var database = mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        _projects = database.GetCollection<Project>(mongoDbOptions.Value.ProjectsCollection);
    }

    public async Task<IEnumerable<Project>> GetAll(int userId = 0, int skip = 0, int limit = 0)
    {
        FilterDefinition<Project>? filter = null;

        if (userId > 0)
        {
            filter = Builders<Project>.Filter.Eq(p => p.UserId, userId);
        }

        var options = new FindOptions<Project>();
        if (skip > 0)
        {
            options.Skip = skip;
        }
        if (limit > 0)
        {
            options.Limit = limit;
        }

        var entities = filter is not null
            ? await _projects.FindAsync(filter, options)
            : await _projects.FindAsync(_ => true, options);

        return await entities.ToListAsync();
    }

    public async Task<Project> GetById(int userId)
    {
        var filter = Builders<Project>.Filter.And(
            Builders<Project>.Filter.Eq(p => p.UserId, userId)
        );

        return await _projects.Find(filter).FirstOrDefaultAsync();
    }

    public async Task Create(Project project)
    {
        if (project is null)
        {
            throw new ArgumentNullException(nameof(project), "Create - Project cannot be null");
        }

        await _projects.InsertOneAsync(project);
    }

    public async Task<bool> Update(Project project)
    {
        if (project is null)
        {
            throw new ArgumentNullException(nameof(project), "Update - Project cannot be null");
        }

        var result = await _projects.ReplaceOneAsync(p => p.UserId == project.UserId, project);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> Delete(int userId)
    {
        var result = await _projects.DeleteOneAsync(p => p.UserId == userId);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public List<IndicatorCount> GetIndicatorsByMultipleUserId(int[] userIds)
    {
        var mostUsedIndicators = _projects.AsQueryable()
            .Where(project => userIds.Contains(project.UserId))
            .SelectMany(document => document.Charts)
            .SelectMany(chart => chart.Indicators)
            .GroupBy(indicator => indicator.Name)
            .Select(g => new IndicatorCount
            {
                Name = g.Key,
                Used = g.Count()
            })
            .OrderByDescending(result => result.Used)
            .ThenBy(result => result.Name)
            .Take(3)
            .ToList();

        return mostUsedIndicators;
    }
}
