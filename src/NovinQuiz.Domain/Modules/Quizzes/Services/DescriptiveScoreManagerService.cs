using NovinQuiz.Modules.Quizzes.Exceptions;
using NovinQuiz.Modules.Quizzes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace NovinQuiz.Modules.Quizzes.Services
{
    public sealed class DescriptiveScoreManagerService : DomainService
    {
        public static IList<DescriptiveScore> CheckDescriptiveScoresValid(IList<DescriptiveScore> descriptiveScores)
        {
            Check.NotNull(descriptiveScores, nameof(descriptiveScores));

            int descriptiveScoresCount = descriptiveScores.Count;

            if (descriptiveScoresCount > 6)
                throw new DescriptiveScoresCountMoreThanSixException("Domain:DescriptiveScoresCountMoreThanSix")
                    .WithData("DescriptiveScore", nameof(descriptiveScores));

            for (int i = 1; i <= descriptiveScoresCount - 1; i++)
            {
                if (descriptiveScores[i].ScorePeriod == descriptiveScores[i - 1].ScorePeriod)
                    throw new ScorePeriodCannotBeRepeatAsPerviousDescriptiveScoreException("Domain:ScorePeriodCannotBeRepeatAsPerviousDescriptiveScore")
                        .WithData("ScorePeriod", descriptiveScores[i].ScorePeriod);

                else if (descriptiveScores[i].ScorePeriod < descriptiveScores[i - 1].ScorePeriod)
                    throw new ScorePeriodCannotBeMoreThanPerviousDescriptiveScoreException("Domain:ScorePeriodCannotBeMoreThanPerviousDescriptiveScore")
                        .WithData("ScorePeriod", descriptiveScores[i].ScorePeriod)
                        .WithData("PerviousScorePeriod", descriptiveScores[i - 1].ScorePeriod);
            }

            return descriptiveScores!;
        }
    }
}
