using NovinQuiz.Modules.Enums.Quizzes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public record struct MultipleParticipateSettings(byte multipleParticipateChanceCount, MultipleParticipateScoreStatus multipleParticipateScoreStatus)
    {
        public byte MultipleParticipateChanceCount { get; private set; }
            = (byte)Check.Range(multipleParticipateChanceCount, nameof(multipleParticipateChanceCount), (short)1, (short)10);

        public MultipleParticipateScoreStatus MultipleParticipateScoreStatus { get; private set; }
            = Check.NotNull(multipleParticipateScoreStatus, nameof(multipleParticipateScoreStatus));
    }
}