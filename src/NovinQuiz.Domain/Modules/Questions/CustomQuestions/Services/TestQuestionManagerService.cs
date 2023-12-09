using NovinQuiz.Modules.Questions.CustomQuestions.Exceptions;
using NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Services
{
    public class TestQuestionManagerService
    {
        public List<TestQuestionChoice> CheckQuestionChoicesValid(List<TestQuestionChoice> choices)
        {
            Check.NotNull(choices, nameof(choices));

            if (choices.Count(c => c.IsCorrect) > 1)
                throw new CorrectAnswerCannotBeMoreThanOneException("Domain:CorrectAnswerCannotBeMoreThanOne");

            return choices;
        }
    }
}
