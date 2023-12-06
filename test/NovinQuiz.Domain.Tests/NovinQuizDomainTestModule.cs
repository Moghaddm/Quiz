using NovinQuiz.MongoDB;
using Volo.Abp.Modularity;

namespace NovinQuiz;

[DependsOn(
    typeof(NovinQuizMongoDbTestModule)
    )]
public class NovinQuizDomainTestModule : AbpModule
{

}
