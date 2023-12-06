using NovinQuiz.MongoDB;
using Xunit;

namespace NovinQuiz;

[CollectionDefinition(NovinQuizTestConsts.CollectionDefinitionName)]
public class NovinQuizDomainCollection : NovinQuizMongoDbCollectionFixtureBase
{

}
