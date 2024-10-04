using Volo.Abp.Modularity;

namespace FlyBookingSystem;

public abstract class FlyBookingSystemApplicationTestBase<TStartupModule> : FlyBookingSystemTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
