using NovinQuiz.Modules.Quizzes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public class MultipleParticipateSettings : ValueObject
    {
        public byte MultipleParticipateChanceCount { get; private set; }
        public MultipleParticipateScoreStatus MultipleParticipateScoreStatus { get; private set; }

        public MultipleParticipateSettings(byte MultipleParticipateChanceCount, MultipleParticipateScoreStatus MultipleParticipateScoreStatus)
        {

        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return MultipleParticipateChanceCount;
            yield return MultipleParticipateScoreStatus;
        }
    }
}