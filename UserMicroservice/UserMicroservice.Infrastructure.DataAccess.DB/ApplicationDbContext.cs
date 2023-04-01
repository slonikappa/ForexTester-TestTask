using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using UserMicroservice.Domain.Core.Entities;
using UserMicroservice.Domain.Core.Enums;

namespace UserMicroservice.Infrastructure.DataAccess.DB;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Seed data
        var subs = new Subscription[]
        {
            new Subscription
            {
                Id = 1,
                Type = SubscriptionType.Free,
                startDate = DateTime.Now.ToUniversalTime(),
                endDate = new DateTime(2024, 04, 29).ToUniversalTime(),
            },
            new Subscription
            {
                Id = 2,
                Type = SubscriptionType.Trial,
                startDate = DateTime.Now.ToUniversalTime(),
                endDate = new DateTime(2024, 04, 29).ToUniversalTime(),
            }
        };

        modelBuilder.Entity<Subscription>().HasData(subs);

        modelBuilder.Entity<User>().HasData(
            new User[]
            {
                new()
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "John@example.com",
                    SubscriptionId = 1,
                },
                new()
                {
                    Id = 2,
                    Name = "Mark Shimko",
                    Email = "Mark@example.com",
                    SubscriptionId = 2,
                },
            });
        #endregion

        modelBuilder
            .Entity<Subscription>()
            .Property(p => p.Type)
            .HasConversion(new EnumToStringConverter<SubscriptionType>());

        base.OnModelCreating(modelBuilder);
    }
}