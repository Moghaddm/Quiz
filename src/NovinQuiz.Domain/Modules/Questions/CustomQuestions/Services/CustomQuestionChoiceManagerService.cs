using NovinQuiz.Modules.Questions.CustomQuestions.Exceptions;
using NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Services
{
    public sealed class CustomQuestionChoiceManagerService : DomainService
    {
        public static List<QuestionChoice> CheckQuestionChoicesValid(List<QuestionChoice> choices)
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
