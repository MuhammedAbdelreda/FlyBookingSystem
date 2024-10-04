using FlyBookingSystem.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FlyBookingSystem.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FlyBookingSystemController : AbpControllerBase
{
    protected FlyBookingSystemController()
    {
        LocalizationResource = typeof(FlyBookingSystemResource);
    }
}
