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
    public sealed class ChoiceManagerService : DomainService
    {
        public static List<TrueFalseChoice> CheckChoicesValid(List<TrueFalseChoice> choices)
        {
            Check.NotNull(choices, nameof(choices));

            if (choices.Count > 8)
                throw new QuestionChoicesCountCannotBeMoreThanEightException("Domain:QuestionChoicesCountCannotBeMoreThanEight");

            if (choices.Count(c => c.CorrectionStatus == NovinQuiz.Enums.Questions.CustomQuestions.ChoiceCorrectionStatus.Correct) > 1)
                throw new CorrectAnswerCannotBeMoreThanOneException("Domain:CorrectAnswerCannotBeMoreThanOne");

            return choices;
        }

        public static List<TestChoice> CheckChoicesValid(List<TestChoice> choices)
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
