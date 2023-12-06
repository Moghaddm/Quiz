using NovinQuiz.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NovinQuiz.Permissions;

public class NovinQuizPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NovinQuizPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(NovinQuizPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NovinQuizResource>(name);
    }
}
