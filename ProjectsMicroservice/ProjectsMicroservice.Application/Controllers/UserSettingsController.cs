using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ProjectsMicroservice.Domain.Core.Entities;
using ProjectsMicroservice.Domain.Infrastructure.Interfaces;

namespace ProjectsMicroservice.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserSettingsController : ControllerBase
{
    private readonly IUserSettingsService _userSettingsService;

    public UserSettingsController(IUserSettingsService userSettingsService)
    {
        _userSettingsService = userSettingsService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserSettings>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll()
    {
        var list = await _userSettingsService.GetSettingsList();

        if (!list.Any())
        {
            return NotFound();
        }

        return Ok(list);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Add(UserSettings userSettings)
    {
        await _userSettingsService.AddSettings(userSettings);

        return Ok();
    }
}
