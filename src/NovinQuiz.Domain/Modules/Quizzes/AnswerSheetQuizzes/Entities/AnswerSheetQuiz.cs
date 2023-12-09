using NovinQuiz.Modules.Questions.AnswerSheetQuestions.ValueObjects;
using NovinQuiz.Modules.Quizzes.Aggregates;
using NovinQuiz.Modules.Quizzes.AnswerSheetQuizzes.ValueObjects;
using NovinQuiz.Modules.Quizzes.Enums;
using NovinQuiz.Modules.Quizzes.Exceptions;
using NovinQuiz.Modules.Quizzes.Services;
using NovinQuiz.Modules.Quizzes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Quizzes.AnswerSheetQuizzes.Entities
{
    public sealed class AnswerSheetQuiz(string title, QuizType type) : Quiz(title, type)
    {
        public AnswerSheetQuizAttachments Attachments { get; private set; }

        private List<AnswerSheetQuestion> _questions;
        public IReadOnlyCollection<AnswerSheetQuestion> Questions => _questions;
        public float QuestionsScore => (float)_questions.Count / PassScore;

        public void SetQuestions(List<AnswerSheetQuestion> questions)
            => _questions = Check.NotNull(questions, nameof(questions));

        public new void DesignQuiz(string title,
            Description description,
            short timeLimit,
            byte passScore,
            byte scoreCeiling,
            byte negativePoint,
            ParticipatePeriod participatePeriod,
            MultipleParticipateSettings multipleParticipateSettings,
            List<DescriptiveScore> descriptiveScores,
            GeneralQuizSettings generalSettings,
            List<AnswerSheetQuestion> questions,
            AnswerSheetQuizAttachments quizAnswerSheetAttachments)
        {
            DesignQuiz(title,
                description,
                timeLimit,
                passScore,
                scoreCeiling,
                negativePoint,
                participatePeriod,
                multipleParticipateSettings,
                descriptiveScores,
                generalSettings);

            _questions = Check.NotNull(questions, nameof(questions)).Count == 0
                ? throw new QuestionsCountCannotBeZeroException("Domain:QuestionsCountCannotBeZero").WithData("Quiz", title)
                : questions;

            Attachments = Check.NotNull(quizAnswerSheetAttachments, nameof(quizAnswerSheetAttachments));
        }
    }
}
