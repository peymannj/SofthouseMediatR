using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SofthouseMediatR.DataContext;

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDataContext>
{
    public ApplicationDataContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Default");
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDataContext>()
            .UseSqlServer(connectionString);

        return new ApplicationDataContext(optionsBuilder.Options);
    }
}
