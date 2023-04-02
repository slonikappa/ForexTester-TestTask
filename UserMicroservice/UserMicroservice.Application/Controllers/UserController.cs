using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using UserMicroservice.Application.Mappers;
using UserMicroservice.Application.Models;
using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Core.Enums;
using UserMicroservice.Domain.Infastructure.Interfaces;

namespace UserMicroservice.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    private readonly IApplicationMapper _mapper;

    public UserController(ILogger<UserController> logger,
        IUserService userService,
        IApplicationMapper mapper)
    {
        _logger = logger;
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _userService.GetUsers();

        if (!users.Any())
        {
            return NotFound();
        }

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _userService.GetById(id);

        if(user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpGet("including-subscription")]
    public async Task<IActionResult> GetWithSubscription()
    {
        var users = await _userService.GetAllWithSubscriptions();

        if (!users.Any())
        {
            return NotFound();
        }

        return Ok(users);
    }

    [HttpGet("all-by-subscription/{subscriptionType}")]
    public async Task<IActionResult> GetAllBySubscriptionType(SubscriptionType subscriptionType)
    {
        var users = await _userService.GetUsersBySubscriptionType(subscriptionType);

        if (!users.Any())
        {
            return NotFound();
        }

        return Ok(users);
    }

    [HttpPost]
    public IActionResult Add([FromBody] AddUserRequestModel model)
    {
        var userToAdd = _mapper.AddModelToUserWithSubscription(model);

        _userService.AddUserWithSubscription(userToAdd);

        return CreatedAtAction(nameof(GetWithSubscription), userToAdd);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateUserRequestModel model)
    {
        var user = await _userService.GetById(id);

        if (user is null)
        {
            return NotFound();
        }

        var userToUpdate = _mapper.UpdateModelToUser(user, model);

        await _userService.UpdateUser(userToUpdate);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userService.GetById(id);

        if (user is null)
        {
            return NotFound();
        }

        await _userService.RemoveUser(user);

        return NoContent();
    }
}
