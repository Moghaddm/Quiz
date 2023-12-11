using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects
{
    public sealed class ChoiceText(string text, CustomQuestionAttachments? attachments) : Choice(text, attachments)
    {
        public string Text { get; private set; } = Check.NotNullOrWhiteSpace(text, nameof(text));
        public CustomQuestionAttachments? Attachments { get; private set; } = attachments;
    }
}
