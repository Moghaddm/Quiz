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
    public class BlankQuestionManagerService
    {
        public List<BlankAnswerSections> CheckAnswersValid(List<BlankAnswerSections> answers, CustomQuestionText text)
        {
            Check.NotNull(answers, nameof(answers));

            answers.ForEach(a =>
            {
                if (a.EndIndex - a.StartIndex <= 0)
                    throw new BlankAnswerSectionLengthCannotBeZeroOrLessException("Domain:BlankAnswerSectionLengthCannotBeZeroOrLess")
                    .WithData("StartIndex", a.StartIndex)
                    .WithData("EndIndex", a.EndIndex);

                if (a.EndIndex - a.StartIndex == text.Value.Length - 1)
                    throw new BlankAnswerSectionCannotHaveAllTheTextInQuestionException("Domain:BlankAnswerSectionCannotHaveAllTheTextInQuestion");
            });

            return answers;
        }
    }
}
