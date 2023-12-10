using NovinQuiz.Modules.Questions.CustomQuestions.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ShortAnswers.Services
{
    public class ShortAnswerQuestionManagerService
    {
        public List<string> CheckAnswersValid(List<string> answerQuestions)
        {
            Check.Range(answerQuestions.Count, nameof(answerQuestions.Count), 1, 5);

            if (answerQuestions.Distinct().Count() != answerQuestions.Count)
                throw new ChoicesCannotHaveDistinctAnswersException("Domain:ChoicesCannotHaveDistinctAnswers");

            return answerQuestions;
        }
    }
}
