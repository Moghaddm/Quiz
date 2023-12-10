using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Common.ValueObjects
{
    public record struct CustomQuestionText(string value, bool rightToLeft)
    {
        public string Value { get; private set; } = Check.NotNullOrWhiteSpace(value, nameof(value));
        public bool RightToLeft { get; private set; } = rightToLeft;
    }
}
