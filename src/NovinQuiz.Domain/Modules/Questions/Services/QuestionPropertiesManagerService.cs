using NovinQuiz.Modules.Quizzes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace NovinQuiz.Modules.Questions.Services
{
    public class QuestionPropertiesManagerService : DomainService
    {
        public List<Question> CheckSumScore(List<Question> questions, byte passScore)
        {
            int sumScore = questions.Sum(q => q.Score);

            if (sumScore > passScore)
                throw new PassScoreCannotBeMoreThanSumQuestionScoresException("Domain:PassScoreCannotBeMoreThanSumQuestionScores")
                {
                    Data =
                    {
                        { "SumScores", sumScore }
                    }
                };

            return questions;
        }

        public Question CheckSumScore(Question question, byte passScore, List<Question> questions)
        {

            int sumScore = questions.Sum(q => q.Score);

            if (sumScore + question.Score > passScore)
                throw new PassScoreCannotBeMoreThanSumQuestionScoresException("Domain:PassScoreCannotBeMoreThanSumQuestionScores")
                {
                    Data =
                    {
                        { "SumScores", sumScore }
                    }
                };

            return question;
        }
    }
}
