using NovinQuiz.Modules.Questions.AnswerSheetQuestions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Common.ValueObjects
{
    public record struct AnswerChoiceTextItem
    {
        public AnswerChoiceTextItem(string text, CustomQuestionAttachments? attachments)
            => (Text, Attachments) = (Check.NotNullOrWhiteSpace(text, nameof(text)), attachments);

        public string Text { get; private set; }
        public CustomQuestionAttachments? Attachments { get; private set; }
    }
}
