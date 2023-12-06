using Volo.Abp.Modularity;

namespace NovinQuiz;

[DependsOn(
    typeof(NovinQuizApplicationModule),
    typeof(NovinQuizDomainTestModule)
    )]
public class NovinQuizApplicationTestModule : AbpModule
{

}
