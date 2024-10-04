using Volo.Abp.Settings;

namespace FlyBookingSystem.Settings;

public class FlyBookingSystemSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(FlyBookingSystemSettings.MySetting1));
    }
}
