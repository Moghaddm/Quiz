using NovinQuiz.Modules.Questions.CustomQuestions.Entities;
using NovinQuiz.Modules.Quizzes.CustomQuizzes.Entities;
using NovinQuiz.Modules.Quizzes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Services
{
    public class QuestionCustomPropertiesManagerService : DomainService
    {
        public float CheckCanSetQuestionScore(CustomQuiz quiz, float score)
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

        //public TQuestion CheckSumScore<TQuestion>(CustomQuiz quiz) where TQuestion : CustomQuestion
        //{

        //    int sumScore = quiz.Questions.Sum(q => q.Score);

        //    if (sumScore + quiz.Questions.Score > passScore)
        //        throw new PassScoreCannotBeMoreThanSumQuestionScoresException("Domain:PassScoreCannotBeMoreThanSumQuestionScores")
        //        {
        //            Data =
        //            {
        //                { "SumScores", sumScore }
        //            }
        //        };
         
        //    return question;
        //}
    }
}
