using System.Threading.Tasks;

namespace NovinQuiz.Data;

public interface INovinQuizDbSchemaMigrator
{
    Task MigrateAsync();
}
