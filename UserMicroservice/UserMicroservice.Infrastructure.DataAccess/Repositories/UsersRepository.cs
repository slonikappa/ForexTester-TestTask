using Microsoft.EntityFrameworkCore;

using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Infastructure.Interfaces;
using UserMicroservice.Infrastructure.DataAccess.DB;

namespace UserMicroservice.Infrastructure.DataAccess.Repositories;

public sealed class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _ctx;

    public UsersRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public void Add(User entity) => _ctx.Users.Add(entity);

    public void DeleteById(int id)
    {
        var entity = _ctx.Users.Find(id);

        if (entity is null)
        {
            throw new NullReferenceException();
        }

        _ctx.Users.Remove(entity);
    }

    public void DeleteByItem(User entity) => _ctx.Users.Remove(entity);

    public async Task<List<User>> GetAll() => await _ctx.Users.ToListAsync();

    public async Task<List<User>> GetAllWithSubscriptions()
    {
        return await _ctx
            .Users
            .Include(user => user.Subscription)
            .ToListAsync();
    }

    public async Task<User?> GetItem(int id) => await _ctx.Users.FindAsync(id);

    public void Update(User entity) => _ctx.Users.Update(entity);
}
