using NovinQuiz.Modules.Questions;
using NovinQuiz.Modules.Quizzes.Exceptions;
using NovinQuiz.Modules.Quizzes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace NovinQuiz.Modules.Quizzes.Services
{
    public class QuizPropertiesManagerService : DomainService
    {
        public byte IsPassScoreValid(byte passScore, byte scoreCeiling)
        {
            Check.NotNull(passScore, nameof(passScore));

            _ = (byte)Check.Positive(passScore, nameof(passScore)) > scoreCeiling
            ? throw new PassScoreCannotBeEqualMoreThanScoreCeilingException("Domain:PassScoreCannotBeEqualMoreThanScoreCeiling").WithData("PassScore", passScore)
            : passScore;

            return passScore;
        }

        public List<DescriptiveScore> IsDescriptiveScoreValid(List<DescriptiveScore> descriptiveScores)
        {
            Check.NotNull(descriptiveScores, nameof(descriptiveScores));

            if (descriptiveScores.Count > 6 && descriptiveScores is not null)
                throw new DescriptiveScoresCountMoreThanSixException("Domain:DescriptiveScoresCountMoreThanSix")
                    .WithData("DescriptiveScore", nameof(descriptiveScores));

            return descriptiveScores!;
        }

        public DescriptiveScore IsDescriptiveScoreValid(DescriptiveScore descriptiveScore, List<DescriptiveScore> descriptiveScores)
        {
            Check.NotNull(descriptiveScore, nameof(descriptiveScore));

            if (descriptiveScores.Count > 6 && descriptiveScore is not null)
                throw new DescriptiveScoresCountMoreThanSixException("Domain:DescriptiveScoresCountMoreThanSix")
                    .WithData("DescriptiveScore", nameof(descriptiveScore));

            return descriptiveScore!;
        }

       
    }
}
