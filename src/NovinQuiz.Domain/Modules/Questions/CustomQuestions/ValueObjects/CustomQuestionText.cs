using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects
{
    public record struct CustomQuestionText
    {
        public CustomQuestionText(string value, bool rightToLeft)
            => (Value, RightToLeft) = (Check.NotNullOrWhiteSpace(value, nameof(value)), rightToLeft);

        public string Value { get; private set; }
        public bool RightToLeft { get; private set; }
    }
}
