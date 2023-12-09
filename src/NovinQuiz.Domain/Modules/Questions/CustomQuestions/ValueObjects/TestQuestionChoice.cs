using NovinQuiz.Modules.Questions.AnswerSheetQuestions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects
{
    public record TestQuestionChoice(string text, bool isCorrect, CustomQuestionAttachments attachments)
    {
        public string Text { get; private set; } = Check.NotNullOrWhiteSpace(text, nameof(text));
        public bool IsCorrect { get; private set; } = isCorrect;
        public CustomQuestionAttachments Attachments { get; private set; } = Check.NotNull(attachments, nameof(attachments));
    }
}
