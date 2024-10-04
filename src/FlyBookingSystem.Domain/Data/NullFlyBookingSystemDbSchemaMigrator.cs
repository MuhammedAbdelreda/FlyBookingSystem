using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FlyBookingSystem.Data;

/* This is used if database provider does't define
 * IFlyBookingSystemDbSchemaMigrator implementation.
 */
public class NullFlyBookingSystemDbSchemaMigrator : IFlyBookingSystemDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
