using NovinQuiz.Modules.Questions.CustomQuestions.Common.Exceptions;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Common.Services
{
    public class QuestionChoiceManagerService
    {
        public List<QuestionChoice> CheckQuestionChoicesValid(List<QuestionChoice> choices)
        {
            Check.NotNull(choices, nameof(choices));

            if (choices.Count > 8)
                throw new QuestionChoicesCountCannotBeMoreThanEightException("Domain:QuestionChoicesCountCannotBeMoreThanEight");

            if (choices.Count(c => c.IsCorrect) > 1)
                throw new CorrectAnswerCannotBeMoreThanOneException("Domain:CorrectAnswerCannotBeMoreThanOne");

            return choices;
        }
    }
}
