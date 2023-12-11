using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public record struct DescriptiveScore(double scorePeriod, string description, byte passScore)
    {
        public double ScorePeriod { get; private set; } = Check.Range(scorePeriod, nameof(scorePeriod), 0, passScore);
        public string Description { get; private set; } = Check.NotNullOrEmpty(description, nameof(description), minLength: 3, maxLength: 100);
    }
}
