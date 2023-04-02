using Microsoft.Extensions.Options;

using MongoDB.Driver;

using ProjectsMicroservice.Domain.Core.Options;
using ProjectsMicroservice.Domain.Core.Entities;
using ProjectsMicroservice.Domain.Infrastructure.Interfaces;
using MongoDB.Bson;

namespace ProjectsMicroservice.Infrastructure.DataAccess.Repositories;

public class UserSettingsRepository : IRepository<UserSettings>
{
    private readonly IMongoCollection<UserSettings> _userSettings;

    public UserSettingsRepository(IMongoClient mongoClient, IOptions<MongoDbOptions> mongoDbOptions)
    {
        if (string.IsNullOrWhiteSpace(mongoDbOptions.Value.DatabaseName))
        {
            throw new ArgumentException("Database name cannot be null or whitespace.", nameof(mongoDbOptions));
        }

        var database = mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        _userSettings = database.GetCollection<UserSettings>(mongoDbOptions.Value.UserSettingsCollection);
    }

    public async Task<IEnumerable<UserSettings>> GetAll(int userId = 0, int skip = 0, int limit = 0)
    {
        FilterDefinition<UserSettings>? filter = null;

        if (userId > 0)
        {
            filter = Builders<UserSettings>.Filter.Eq(p => p.UserId, userId);
        }

        var options = new FindOptions<UserSettings>();
        if (skip > 0)
        {
            options.Skip = skip;
        }
        if (limit > 0)
        {
            options.Limit = limit;
        }

        var entities = filter is not null
            ? await _userSettings.FindAsync(filter, options)
            : await _userSettings.FindAsync(_ => true, options);

        return await entities.ToListAsync();
    }

    public async Task<UserSettings> GetById(int userId)
    {
        return await _userSettings.Find(u => u.UserId == userId).FirstOrDefaultAsync();
    }

    public async Task Create(UserSettings userSettings)
    {
        if (userSettings is null)
        {
            throw new ArgumentNullException(nameof(userSettings), "Create - User settings cannot be null");
        }

        await _userSettings.InsertOneAsync(userSettings);
    }

    public async Task<bool> Update(UserSettings userSettings)
    {
        if (userSettings is null)
        {
            throw new ArgumentNullException(nameof(userSettings), "Update - User settings cannot be null");
        }

        var result = await _userSettings.ReplaceOneAsync(u => u.UserId == userSettings.UserId, userSettings);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> Delete(int userId)
    {
        var result = await _userSettings.DeleteOneAsync(u => u.UserId == userId);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}