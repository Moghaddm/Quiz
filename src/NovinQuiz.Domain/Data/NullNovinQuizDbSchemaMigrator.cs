using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace NovinQuiz.Data;

/* This is used if database provider does't define
 * INovinQuizDbSchemaMigrator implementation.
 */
public class NullNovinQuizDbSchemaMigrator : INovinQuizDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
