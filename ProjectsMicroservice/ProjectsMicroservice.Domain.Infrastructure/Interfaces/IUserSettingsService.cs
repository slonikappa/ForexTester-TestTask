using ProjectsMicroservice.Domain.Core.Entities;

namespace ProjectsMicroservice.Domain.Infrastructure.Interfaces;

public interface IUserSettingsService
{
    Task AddSettings(UserSettings userSettings);
    Task UpdateSettings(UserSettings userSettings);
    Task DeleteSettings(int userId);
    Task<IEnumerable<UserSettings>> GetSettingsList();
    Task<UserSettings> GetSettingsByUserId(int usedId);
}
