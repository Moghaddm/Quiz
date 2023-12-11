using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects
{
    public class MultipleChoiceChanceItem : ValueObject
    {
        public MultipleChoiceChanceItem(ChoiceText text, byte score, byte negativePoint, bool isCorrect)
            => (Text, Score, NegativePoint, IsCorrect) = (Check.NotNull(text, nameof(text)), score, negativePoint, isCorrect);

        public ChoiceText Text { get; private set; }
        public byte Score { get; private set; }
        public byte NegativePoint { get; private set; }
        public bool IsCorrect { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Text;
            yield return IsCorrect;
        }
    }
}
