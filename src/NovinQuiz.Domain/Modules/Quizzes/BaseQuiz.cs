using NovinQuiz.Modules.Common.ValueObjects;
using NovinQuiz.Modules.Enums.Quizzes;
using NovinQuiz.Modules.Questions.CustomQuestions;
using NovinQuiz.Modules.Quizzes.Exceptions;
using NovinQuiz.Modules.Quizzes.Services;
using NovinQuiz.Modules.Quizzes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace NovinQuiz.Modules.Quizzes
{
    public abstract class BaseQuiz(string title, QuizType type) : FullAuditedAggregateRoot<string>
    {
        public string Title { get; private set; } = Check.NotNullOrEmpty(title, nameof(title));
        public QuizType Type { get; } = Check.NotNull(type, nameof(type));
        public Description Description { get; private set; }
        public ActivateStatus Status { get; private set; } // can done in other service dependencies
        public short TimeLimit { get; private set; } // according to minutes for save
        public byte PassScore { get; private set; }
        public byte ScoreCeiling { get; private set; }
        public byte NegativePoint { get; private set; }
        public ParticipatePeriod ParticipatePeriodTime { get; private set; }
        public MultipleParticipateSettings MultipleParticipateSettings { get; private set; }
        public IList<DescriptiveScore> DescriptiveScores { get; private set; }
        public GeneralQuizSettings GeneralSettings { get; private set; }

        public void ActivateQuiz() => Status = ActivateStatus.Active;
        public void DeActiveQuiz() => Status = ActivateStatus.NotActive;

        public void DesignQuiz(string title,
            Description description,
            short timeLimit,
            byte passScore,
            byte scoreCeiling,
            byte negativePoint,
            ParticipatePeriod participatePeriod,
            MultipleParticipateSettings multipleParticipateSettings,
            List<DescriptiveScore> descriptiveScores,
            GeneralQuizSettings generalSettings)
        {
            Title = Check.NotNullOrEmpty(title, nameof(title));
            Description = Check.NotNull(description, nameof(description));

            checked
            {
                TimeLimit = Check.Positive(timeLimit, nameof(timeLimit));
                ScoreCeiling = (byte)Check.Positive(scoreCeiling, nameof(scoreCeiling));

                Check.NotNull(passScore, nameof(passScore));
                PassScore = (byte)Check.Positive(passScore, nameof(passScore)) > scoreCeiling
                    ? throw new PassScoreCannotBeEqualMoreThanScoreCeilingException("Domain:PassScoreCannotBeEqualMoreThanScoreCeiling")
                        .WithData("PassScore", passScore)
                    : passScore;

                NegativePoint = (byte)Check.Range(negativePoint, nameof(negativePoint), minimumValue: (short)1, maximumValue: (short)10);
            }

            ParticipatePeriodTime = Check.NotNull(participatePeriod, nameof(participatePeriod));
            MultipleParticipateSettings = Check.NotNull(multipleParticipateSettings, nameof(multipleParticipateSettings));
            DescriptiveScores = DescriptiveScoreManagerService.CheckDescriptiveScoresValid(descriptiveScores);
            GeneralSettings = Check.NotNull(generalSettings, nameof(generalSettings));
        }
    }
}
