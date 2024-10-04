using FlyBookingSystem.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace FlyBookingSystem.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FlyBookingSystemEntityFrameworkCoreModule),
    typeof(FlyBookingSystemApplicationContractsModule)
    )]
public class FlyBookingSystemDbMigratorModule : AbpModule
{
}
