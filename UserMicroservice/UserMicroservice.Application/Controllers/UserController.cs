using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Infastructure.Interfaces;

namespace UserMicroservice.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger,
        IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    // GET: api/<UserController>
    [HttpGet]
    public async Task<List<User>> Get()
    {
        return await _userService.GetUsers();
    }

    // GET api/<UserController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // GET api/<UserController>/5
    [HttpGet("/user-with-subscription")]
    public async Task<List<User>> GetWithSubscription()
    {
        return await _userService.GetAllWithSubscriptions();
    }

    // POST api/<UserController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<UserController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
