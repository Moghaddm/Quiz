using NovinQuiz.Modules.Questions.AnswerSheetQuestions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.AnswerSheetQuestions.ValueObjects
{
    public record AnswerSheetQuestion(byte questionNumber, AnswerSheetQuestionChoices choices, byte correctChoice)
    {
        public short QuestionNumber { get; private set; } = Check.Positive(questionNumber, nameof(questionNumber));
        public AnswerSheetQuestionChoices Choices { get; private set; } = choices;
        public byte CorrectChoice { get; private set; } = (byte)Check.Range(correctChoice, nameof(correctChoice), 1, (int)choices);
    }
}