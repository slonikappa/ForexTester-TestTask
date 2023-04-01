using Microsoft.EntityFrameworkCore;

using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Infastructure.Interfaces;
using UserMicroservice.Infrastructure.DataAccess.DB;

namespace UserMicroservice.Infrastructure.DataAccess.Repositories;

public class SubscriptionsRepository : IRepository<Subscription>
{
    private readonly ApplicationDbContext _ctx;

    public SubscriptionsRepository(ApplicationDbContext ctx)
    {
        _ctx = ctx;
    }

    public void Add(Subscription entity) => _ctx.Subscriptions.Add(entity);

    public void DeleteById(int id)
    {
        var entity = _ctx.Subscriptions.Find(id);

        if(entity is null)
        {
            throw new NullReferenceException();
        }

        _ctx.Subscriptions.Remove(entity);
    }

    public void DeleteByItem(Subscription entity) => _ctx.Subscriptions.Remove(entity);

    public async Task<List<Subscription>> GetAll() => await _ctx.Subscriptions.ToListAsync();

    public async Task<Subscription?> GetItem(int id) => await _ctx.Subscriptions.FindAsync(id);

    public void Update(Subscription entity) => _ctx.Subscriptions.Update(entity);
}
