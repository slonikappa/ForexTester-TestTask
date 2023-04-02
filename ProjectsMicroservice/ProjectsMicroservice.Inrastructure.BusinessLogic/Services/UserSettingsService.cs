using ProjectsMicroservice.Domain.Core.Entities;
using ProjectsMicroservice.Domain.Infrastructure.Interfaces;

namespace ProjectsMicroservice.Inrastructure.BusinessLogic.Services;

public class UserSettingsService : IUserSettingsService
{
    private readonly IRepository<UserSettings> _userSettingsRepository;

    public UserSettingsService(IRepository<UserSettings> userSettingsRepository)
    {
        _userSettingsRepository = userSettingsRepository;
    }

    public async Task AddSettings(UserSettings userSettings)
    {
        await _userSettingsRepository.Create(userSettings);
    }

    public async Task DeleteSettings(int userId)
    {
        await _userSettingsRepository.Delete(userId);
    }

    public async Task<UserSettings> GetSettingsByUserId(int usedId)
    {
        return await _userSettingsRepository.GetById(usedId);
    }

    public async Task<IEnumerable<UserSettings>> GetSettingsList()
    {
        return await _userSettingsRepository.GetAll();
    }

    public async Task<IEnumerable<UserSettings>> GetAll()
    {
        return await _userSettingsRepository.GetAll();
    }

    public async Task UpdateSettings(UserSettings userSettings)
    {
        await _userSettingsRepository.Update(userSettings);
    }
}
 
