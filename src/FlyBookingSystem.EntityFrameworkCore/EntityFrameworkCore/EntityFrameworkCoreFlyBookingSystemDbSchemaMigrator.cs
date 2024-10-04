using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FlyBookingSystem.Data;
using Volo.Abp.DependencyInjection;

namespace FlyBookingSystem.EntityFrameworkCore;

public class EntityFrameworkCoreFlyBookingSystemDbSchemaMigrator
    : IFlyBookingSystemDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreFlyBookingSystemDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the FlyBookingSystemDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<FlyBookingSystemDbContext>()
            .Database
            .MigrateAsync();
    }
}
