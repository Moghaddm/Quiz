using NovinQuiz.Enums.Questions.AnswerSheetQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Questions.AnswerSheetQuestions.ValueObjects
{
    public sealed class AnswerSheetQuestion(short questionNumber, AnswerSheetQuestionChoices choices, AnswerSheetQuestionChoices correctChoice) : ValueObject
    {
        public short QuestionNumber { get; private set; } = Check.Positive(questionNumber, nameof(questionNumber));
        public AnswerSheetQuestionChoices Choices { get; private set; } = choices;
        public AnswerSheetQuestionChoices CorrectChoice { get; private set; } = (AnswerSheetQuestionChoices)Check.Range((int)correctChoice, nameof(correctChoice), 1, (int)choices);

        public void SetChoices(AnswerSheetQuestionChoices choices) => Choices = choices;
        public void SetCorrectChoice(AnswerSheetQuestionChoices correctChoice)
            => CorrectChoice = (AnswerSheetQuestionChoices)Check.Range((int)correctChoice, nameof(correctChoice), 1, (int)choices);

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return QuestionNumber;
            yield return Choices;
            yield return CorrectChoice;
        }
    }
}