using Microsoft.Extensions.Localization;
using FlyBookingSystem.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FlyBookingSystem;

[Dependency(ReplaceServices = true)]
public class FlyBookingSystemBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<FlyBookingSystemResource> _localizer;

    public FlyBookingSystemBrandingProvider(IStringLocalizer<FlyBookingSystemResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
