using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace NovinQuiz.MongoDB;

[DependsOn(
    typeof(NovinQuizTestBaseModule),
    typeof(NovinQuizMongoDbModule)
    )]
public class NovinQuizMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = NovinQuizMongoDbFixture.GetRandomConnectionString();
        });
    }
}
