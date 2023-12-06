using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace NovinQuiz;

[Dependency(ReplaceServices = true)]
public class NovinQuizBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "NovinQuiz";
}
