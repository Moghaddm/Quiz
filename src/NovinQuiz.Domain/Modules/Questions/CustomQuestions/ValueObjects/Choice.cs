using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects
{
    public abstract class Choice(string text, CustomQuestionAttachments attachments)
    {
        public string Text { get; private set; } = Check.NotNullOrWhiteSpace(text, nameof(text));
        public CustomQuestionAttachments Attachments { get; private set; } = Check.NotNull(attachments, nameof(attachments));
    }
}
