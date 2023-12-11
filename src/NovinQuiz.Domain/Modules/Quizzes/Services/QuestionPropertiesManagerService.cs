using NovinQuiz.Modules.Quizzes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace NovinQuiz.Modules.Quizzes.Services
{
    public sealed class QuestionPropertiesManagerService : DomainService
    {
        public static float CheckCanSetQuestionScore(CustomQuiz quiz, float score)
        {
            float sumScore = quiz.Questions.Sum(q => q.Score);

            if (sumScore + score > quiz.PassScore)
                throw new PassScoreCannotBeMoreThanSumQuestionScoresException("Domain:PassScoreCannotBeMoreThanSumQuestionScores")
                {
                    Data =
                    {
                        { "SumScores", sumScore }
                    }
                };

            return score;
        }
    }
}
