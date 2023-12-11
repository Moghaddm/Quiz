using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects
{
<<<<<<<< HEAD:src/NovinQuiz.Domain/Modules/Questions/CustomQuestions/ValueObjects/Choice.cs
    public abstract class Choice(string text, CustomQuestionAttachments attachments)
========
    public sealed record QuestionChoice(string text, bool isCorrect, CustomQuestionAttachments attachments)
>>>>>>>> fe097f89e4c7c883e71d565719a98fdac5d8f7d0:src/NovinQuiz.Domain/Modules/Questions/CustomQuestions/ValueObjects/QuestionChoice.cs
    {
        public string Text { get; private set; } = Check.NotNullOrWhiteSpace(text, nameof(text));
        public CustomQuestionAttachments Attachments { get; private set; } = Check.NotNull(attachments, nameof(attachments));
    }
}
