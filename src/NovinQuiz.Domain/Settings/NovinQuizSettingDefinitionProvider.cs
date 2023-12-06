using Volo.Abp.Settings;

namespace NovinQuiz.Settings;

public class NovinQuizSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(NovinQuizSettings.MySetting1));
    }
}
