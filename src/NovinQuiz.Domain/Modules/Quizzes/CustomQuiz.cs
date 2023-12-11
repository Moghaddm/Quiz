using NovinQuiz.Modules.Enums.Quizzes;
using NovinQuiz.Modules.Questions.AnswerSheetQuestions.ValueObjects;
using NovinQuiz.Modules.Questions.CustomQuestions;
using NovinQuiz.Modules.Quizzes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Quizzes
{
    public sealed class CustomQuiz(string title, QuizType type) : BaseQuiz(title, type)
    {
        public List<BaseCustomQuestion> Questions { get; private set; }

        public void AddQuestion(BaseCustomQuestion question) => Questions.Add(Check.NotNull(question, nameof(question)));

        public void RemoveQuestion(BaseCustomQuestion question) => Questions.Remove(Check.NotNull(question, nameof(question)));
    }
}
