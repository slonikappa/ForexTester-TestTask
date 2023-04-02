using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ProjectMicroservices.Infrastructure.External.UsersMicroservice.Enums;

using ProjectsMicroservice.Application.Models;
using ProjectsMicroservice.Domain.Core.Entities;
using ProjectsMicroservice.Domain.Infrastructure.Interfaces;

namespace ProjectsMicroservice.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectsService _projectsService;

    public ProjectsController(IProjectsService projectsService)
    {
        _projectsService = projectsService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int userId)
    {
        var item = await _projectsService.GetProjectByUserId(userId);

        if(item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _projectsService.GetProjectList();

        if (!items.Any())
        {
            return NotFound();
        }

        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Project project)
    {
        await _projectsService.AddProject(project);

        return Ok();
    }

    // TODO: Add int param to have ability to retrieve TOP (value) indicators
    [HttpGet("/api/popularIndicators/{subscriptionType}")]
    public async Task<IActionResult> MostUsedIndicatorNamesTopThree([FromRoute] SubscriptionType subscriptionType)
    {
        var indicators = await _projectsService.GetMostUsedProjectIndicatorsBySubsType(subscriptionType);

        if(!indicators.Any())
        {
            return NotFound();
        }

        return Ok(new MostUsedIndicatorsResponseModel
        {
            Indicators = indicators
        });
    }
}
