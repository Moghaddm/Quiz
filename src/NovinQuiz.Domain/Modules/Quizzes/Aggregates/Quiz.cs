using NovinQuiz.Modules.Common.ValueObjects;
using NovinQuiz.Modules.Quizzes.Enums;
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

namespace NovinQuiz.Modules.Quizzes.Aggregates
{
    public class Quiz : FullAuditedAggregateRoot<string>
    {
        public string Title { get; protected set; }
        public QuizType Type { get; }
        public Description Description { get; protected set; }
        public ActivateStatus Status { get; protected set; } // perform at lims
        public void ActivateQuiz() => Status = ActivateStatus.Active;
        public void DeActiveQuiz() => Status = ActivateStatus.NotActive;
        public short TimeLimit { get; protected set; } // according to minutes for save
        public byte PassScore { get; protected set; }
        public byte ScoreCeiling { get; protected set; }
        public byte NegativePoint { get; protected set; }
        public ParticipatePeriod ParticipatePeriodTime { get; protected set; }
        public MultipleParticipateSettings MultipleParticipateSettings { get; protected set; }
        public List<DescriptiveScore> DescriptiveScores { get; protected set; }
        public GeneralQuizSettings GeneralSettings { get; protected set; }

        public Quiz(string title, QuizType type)
            => (Title, Type) = (Check.NotNullOrEmpty(title, nameof(title)), Check.NotNull(type, nameof(type)));

        public virtual void DesignQuiz(string title,
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
                PassScore = (byte)Check.Positive(passScore, nameof(passScore));
                NegativePoint = (byte)Check.Range(negativePoint, nameof(negativePoint), minimumValue: (short)1, maximumValue: (short)10);
            }

            ParticipatePeriodTime = Check.NotNull(participatePeriod, nameof(participatePeriod));
            MultipleParticipateSettings = Check.NotNull(multipleParticipateSettings, nameof(multipleParticipateSettings));
            DescriptiveScores = new DescriptiveScoreManagerService().CheckDescriptiveScoresValid(descriptiveScores);
            GeneralSettings = Check.NotNull(generalSettings, nameof(generalSettings));
        }
    }
}
