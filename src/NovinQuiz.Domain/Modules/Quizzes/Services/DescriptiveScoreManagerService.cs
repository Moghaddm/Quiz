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
    public class DescriptiveScoreManagerService : DomainService
    {
        public List<DescriptiveScore> CheckDescriptiveScoresValid(List<DescriptiveScore> descriptiveScores)
        {
            Check.NotNull(descriptiveScores, nameof(descriptiveScores));

            if (descriptiveScores.Count > 6)
                throw new DescriptiveScoresCountMoreThanSixException("Domain:DescriptiveScoresCountMoreThanSix")
                    .WithData("DescriptiveScore", nameof(descriptiveScores));

            for (int i = 1; i <= descriptiveScores.Count - 1; i++)
            {
                if (descriptiveScores[i].ScorePeriod == descriptiveScores[i - 1].ScorePeriod)
                    throw new ScorePeriodCannotBeRepeatAsPerviousDescriptiveScoreException("Domain:ScorePeriodCannotBeRepeatAsPerviousDescriptiveScore")
                    {
                        Data =
                        {
                            {"ScorePeriod", descriptiveScores[i].ScorePeriod}
                        }
                    };

                else if (descriptiveScores[i].ScorePeriod < descriptiveScores[i - 1].ScorePeriod)
                    throw new ScorePeriodCannotBeMoreThanPerviousDescriptiveScoreException("Domain:ScorePeriodCannotBeMoreThanPerviousDescriptiveScore")
                    {
                        Data =
                        {
                            {"ScorePeriod", descriptiveScores[i].ScorePeriod},
                            {"PerviousScorePeriod", descriptiveScores[i - 1].ScorePeriod}
                        }
                    };
            }

            return descriptiveScores!;
        }
    }
}
