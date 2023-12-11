using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects
{
    public sealed class TestChoice(string text, bool isCorrect, CustomQuestionAttachments attachments) : Choice(text, attachments)
    {
        public bool IsCorrect { get; private set; } = isCorrect;
    }
}
