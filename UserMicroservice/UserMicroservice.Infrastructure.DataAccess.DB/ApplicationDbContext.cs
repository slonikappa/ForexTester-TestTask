using Microsoft.EntityFrameworkCore;

namespace UserMicroservice.Infrastructure.DataAccess.DB;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base()
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}