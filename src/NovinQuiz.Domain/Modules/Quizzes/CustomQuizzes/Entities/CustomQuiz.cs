using NovinQuiz.Modules.Questions.CustomQuestions.Entities;
using NovinQuiz.Modules.Quizzes.Aggregates;
using NovinQuiz.Modules.Quizzes.Enums;
using NovinQuiz.Modules.Quizzes.Exceptions;
using NovinQuiz.Modules.Quizzes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Quizzes.CustomQuizzes.Entities
{
    public class CustomQuiz(string title, QuizType type) : Quiz(title, type)
    {
        private List<CustomQuestion> _questions;
        public IReadOnlyCollection<CustomQuestion> Questions => _questions;

        public void AddQuestion(CustomQuestion question)
            => _questions.Add(Check.NotNull(question, nameof(question)));
        public void RemoveQuestion(CustomQuestion question)
            => _questions.Remove(Check.NotNull(question, nameof(question)));

        public override void DesignQuiz(string title,
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
            if (_questions.Count == 0)
                throw new QuestionsCountCannotBeZeroException("Domain:QuestionsCountCannotBeZero").WithData("Quiz", title);

            base.DesignQuiz(title,
                description,
                timeLimit,
                passScore,
                scoreCeiling,
                negativePoint,
                participatePeriod,
                multipleParticipateSettings,
                descriptiveScores,
                generalSettings);
        }
    }
}
