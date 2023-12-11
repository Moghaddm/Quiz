using NovinQuiz.Enums.Questions.CustomQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects
{
    public sealed class PluggableQuestionAnswerItem(AnswerChoiceTextItem first, AnswerChoiceTextItem? second, PluggableQuestionItemType type) : ValueObject
    {
        public AnswerChoiceTextItem First { get; private set; } = Check.NotNull(first, nameof(first));
        public AnswerChoiceTextItem? Second { get; private set; } = second;
        public PluggableQuestionItemType Type { get; private set; } = type;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return First.Text;
            yield return Second.Text;
            yield return Type;
        }
    }
}
