using Volo.Abp.Modularity;

namespace FlyBookingSystem;

[DependsOn(
    typeof(FlyBookingSystemApplicationModule),
    typeof(FlyBookingSystemDomainTestModule)
)]
public class FlyBookingSystemApplicationTestModule : AbpModule
{

}
