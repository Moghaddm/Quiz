using NovinQuiz.Modules.Questions;
using NovinQuiz.Modules.Questions.Services;
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

namespace NovinQuiz.Modules.Quizzes
{
    public sealed class Quiz : AggregateRoot<string>
    {
        public string Title { get; private set; }
        public void SetTitle(string title) => Title = Check.NotNullOrEmpty(title, nameof(title), minLength: 3);

        public Description Description { get; private set; }
        public void SetDescription(Description description)
            => Description = Check.NotNull(description, nameof(description));

        public ActivateStatus Status { get; private set; }
        public void ActivateQuiz() => Status = ActivateStatus.Active;
        public void DeActiveQuiz() => Status = ActivateStatus.NotActive;

        public QuizType Type { get; }

        public short TimeLimit { get; private set; }
        public void SetTimeLimit(short timeLimit) => TimeLimit = Check.Positive(timeLimit, nameof(timeLimit));

        private IList<Attachment> _attachments;
        public IReadOnlyCollection<Attachment> Attachments => _attachments.ToList();
        public void SetAttachments(IList<Attachment> attachments) => _attachments = attachments;
        public void AddAttachment(Attachment attachment) => _attachments.Add(attachment);
        public void RemoveAttachment(Attachment attachment) => _attachments.Remove(attachment);

        public byte PassScore { get; private set; }
        public void SetPassScore(byte passScore)
            => PassScore = new QuizPropertiesManagerService().IsPassScoreValid(passScore, ScoreCeiling);

        public byte ScoreCeiling { get; private set; }
        public void SetScoreCeiling(byte scoreCeiling) => PassScore = (byte)Check.Positive(scoreCeiling, nameof(scoreCeiling));

        public byte NegativePoint { get; private set; }
        public void SetNegativePoint(byte negativePoint)
        {
            unchecked
            {
                PassScore = (byte)Check.Range(negativePoint, nameof(negativePoint), minimumValue: (short)1, maximumValue: (short)10);
            }
        }

        public ParticipatePeriod ParticipatePeriodTime { get; private set; }
        public void SetParticipatePeriodTime(ParticipatePeriod participatePeriodTime)
            => ParticipatePeriodTime = Check.NotNull(participatePeriodTime, nameof(participatePeriodTime));

        public MultipleParticipateSettings MultipleParticipateSettings { get; private set; }
        public void SetMultipleParticipateSettings(MultipleParticipateSettings multipleParticipateSettings)
            => MultipleParticipateSettings = Check.NotNull(multipleParticipateSettings, nameof(multipleParticipateSettings));

        public List<DescriptiveScore> DescriptiveScores { get; private set; }
        public void SetDescriptiveScores(List<DescriptiveScore> descriptiveScores)
            => DescriptiveScores = new QuizPropertiesManagerService().IsDescriptiveScoreValid(descriptiveScores);

        public void AddDescriptiveScores(DescriptiveScore descriptiveScore)
            => DescriptiveScores.Add(new QuizPropertiesManagerService().IsDescriptiveScoreValid(descriptiveScore, DescriptiveScores));

        private List<Question> _questions;
        public IReadOnlyCollection<Question> Questions => _questions;
        public void SetQuestions(List<Question> questions)
            => _questions = new QuestionPropertiesManagerService().CheckSumScore(Check.NotNull(questions, nameof(questions)), PassScore);
        public void AddQuestion(Question question)
            => _questions.Add(new QuestionPropertiesManagerService().CheckSumScore(Check.NotNull(question, nameof(question)), PassScore, _questions));

        public GeneralQuizSettings GeneralSettings { get; private set; }
        public void SetGeneralSettings(GeneralQuizSettings generalSettings) => GeneralSettings = Check.NotNull(generalSettings, nameof(generalSettings));

        private Quiz(string title, QuizType type)
            => (Title, Type) = (title, type);

        private Quiz(string title,
            Description description,
            IList<Attachment> attachments,
            byte passScore,
            byte scoreCeiling,
            byte negativePoint,
            ParticipatePeriod participatePeriod,
            MultipleParticipateSettings multipleParticipateSettings,
            List<DescriptiveScore> descriptiveScores,
            List<Question> questions,
            GeneralQuizSettings generalQuizSettings)
        {
            SetTitle(title);
            SetDescription(description);
            SetAttachments(attachments);
            SetPassScore(passScore);
            SetScoreCeiling(scoreCeiling);
            SetNegativePoint(negativePoint);
            SetParticipatePeriodTime(participatePeriod);
            SetMultipleParticipateSettings(multipleParticipateSettings);
            SetDescriptiveScores(descriptiveScores);
            SetQuestions(questions);
            SetGeneralSettings(generalQuizSettings);
        }

        public static Quiz InitalizeQuiz(string title, QuizType type)
            => new Quiz(title, type);

        public void DesignQuiz(string title,
            Description description,
            IList<Attachment> attachments,
            byte passScore,
            byte scoreCeiling,
            byte negativePoint,
            ParticipatePeriod participatePeriod,
            MultipleParticipateSettings multipleParticipateSettings,
            List<DescriptiveScore> descriptiveScores,
            List<Question> questions,
            GeneralQuizSettings generalQuizSettings)
            => new Quiz(title,
                description,
                attachments,
                passScore,
                scoreCeiling,
                negativePoint,
                participatePeriod,
                multipleParticipateSettings,
                descriptiveScores,
                questions,
                generalQuizSettings);
    }
}
