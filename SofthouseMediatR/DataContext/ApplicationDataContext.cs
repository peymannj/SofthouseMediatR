using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SofthouseMediatR.Models;
using Microsoft.EntityFrameworkCore;
using SofthouseMediatR.Extensions;

namespace SofthouseMediatR.DataContext;

public class ApplicationDataContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Car>().HasKey(x => x.Id);

        // Add Outbox models to the DbContext
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();

        // Seed the database with default Admin and user role
        modelBuilder.SeedIdentityData();
    }

    public DbSet<Car> Cars { get; set; }
}
