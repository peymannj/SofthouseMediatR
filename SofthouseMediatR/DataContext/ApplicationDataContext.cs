using MassTransit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SofthouseMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace SofthouseMediatR.DataContext;

public class ApplicationDataContext : IdentityDbContext
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Car>().HasKey(x => x.Id);

        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
    }

    public DbSet<Car> Cars { get; set; }
}
