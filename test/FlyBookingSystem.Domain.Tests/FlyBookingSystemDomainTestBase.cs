using Volo.Abp.Modularity;

namespace FlyBookingSystem;

/* Inherit from this class for your domain layer tests. */
public abstract class FlyBookingSystemDomainTestBase<TStartupModule> : FlyBookingSystemTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
