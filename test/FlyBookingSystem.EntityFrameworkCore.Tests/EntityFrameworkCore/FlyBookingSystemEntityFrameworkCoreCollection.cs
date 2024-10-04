using Xunit;

namespace FlyBookingSystem.EntityFrameworkCore;

[CollectionDefinition(FlyBookingSystemTestConsts.CollectionDefinitionName)]
public class FlyBookingSystemEntityFrameworkCoreCollection : ICollectionFixture<FlyBookingSystemEntityFrameworkCoreFixture>
{

}
