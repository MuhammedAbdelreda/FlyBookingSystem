using FlyBookingSystem.Samples;
using Xunit;

namespace FlyBookingSystem.EntityFrameworkCore.Applications;

[Collection(FlyBookingSystemTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<FlyBookingSystemEntityFrameworkCoreTestModule>
{

}
