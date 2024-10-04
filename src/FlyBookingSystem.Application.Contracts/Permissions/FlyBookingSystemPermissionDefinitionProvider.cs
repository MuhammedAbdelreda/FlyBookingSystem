using FlyBookingSystem.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FlyBookingSystem.Permissions;

public class FlyBookingSystemPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FlyBookingSystemPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(FlyBookingSystemPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FlyBookingSystemResource>(name);
    }
}
