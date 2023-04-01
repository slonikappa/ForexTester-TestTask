using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Infastructure.Interfaces;
using UserMicroservice.Infrastructure.DataAccess.DB;

namespace UserMicroservice.Infrastructure.DataAccess;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;

    private readonly ILogger<UnitOfWork> _logger;

    public IUsersRepository UsersRepository { get; }
    public IRepository<Subscription> SubscriptionRepository { get; }

    private bool disposedValue = false;

    public UnitOfWork(ApplicationDbContext context,
        IUsersRepository usersRepository,
        IRepository<Subscription> subscriptionRepository,
        ILogger<UnitOfWork> logger)
    {
        _context = context;

        UsersRepository = usersRepository;
        SubscriptionRepository = subscriptionRepository;

        _logger = logger;
    }

    public async Task<bool> SaveChanges(Action func)
    {
        func();

        var transactionResult = true;

        using (var dbTransaction = _context.Database.BeginTransaction())
        {
            try
{
                await _context.SaveChangesAsync();
                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError("UnitOfWork saving transaction failed. ErrorMsg: {1}", ex.Message);

                transactionResult = false;
                dbTransaction.Rollback();
            }
        }

        return transactionResult;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
