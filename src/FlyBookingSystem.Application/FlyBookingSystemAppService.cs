using System;
using System.Collections.Generic;
using System.Text;
using FlyBookingSystem.Localization;
using Volo.Abp.Application.Services;

namespace FlyBookingSystem;

/* Inherit your application services from this class.
 */
public abstract class FlyBookingSystemAppService : ApplicationService
{
    protected FlyBookingSystemAppService()
    {
        LocalizationResource = typeof(FlyBookingSystemResource);
    }
}
