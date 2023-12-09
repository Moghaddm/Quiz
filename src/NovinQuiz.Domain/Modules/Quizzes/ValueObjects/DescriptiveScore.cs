using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public class DescriptiveScore(double scorePeriod, string description, byte passScore) : ValueObject
    {
        public double ScorePeriod { get; private set; } = Check.Range(scorePeriod, nameof(scorePeriod), 0, passScore);
        public string Description { get; private set; } = Check.NotNullOrEmpty(description, nameof(description), minLength: 3, maxLength: 100);

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ScorePeriod; yield return Description;
        }
    }
}
