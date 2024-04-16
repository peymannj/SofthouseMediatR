﻿using SofthouseMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace SofthouseMediatR.DataContext;

public class ApplicationDataContext : DbContext
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>().HasKey(x => x.Id);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Car> Cars { get; set; }
}
