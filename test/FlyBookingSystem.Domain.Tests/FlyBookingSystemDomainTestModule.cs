using Volo.Abp.Modularity;

namespace FlyBookingSystem;

[DependsOn(
    typeof(FlyBookingSystemDomainModule),
    typeof(FlyBookingSystemTestBaseModule)
)]
public class FlyBookingSystemDomainTestModule : AbpModule
{

}
