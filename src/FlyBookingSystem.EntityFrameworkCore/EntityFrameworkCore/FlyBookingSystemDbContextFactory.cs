using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FlyBookingSystem.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class FlyBookingSystemDbContextFactory : IDesignTimeDbContextFactory<FlyBookingSystemDbContext>
{
    public FlyBookingSystemDbContext CreateDbContext(string[] args)
    {
        FlyBookingSystemEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<FlyBookingSystemDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new FlyBookingSystemDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FlyBookingSystem.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
