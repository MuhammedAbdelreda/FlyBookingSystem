using FlyBookingSystem.Samples;
using Xunit;

namespace FlyBookingSystem.EntityFrameworkCore.Domains;

[Collection(FlyBookingSystemTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<FlyBookingSystemEntityFrameworkCoreTestModule>
{

}
