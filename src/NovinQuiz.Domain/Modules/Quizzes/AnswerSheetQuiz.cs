using NovinQuiz.Enums.Questions.AnswerSheetQuestions;
using NovinQuiz.Modules.Enums.Quizzes;
using NovinQuiz.Modules.Questions.AnswerSheetQuestions.ValueObjects;
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

namespace NovinQuiz.Modules.Quizzes
{
    public sealed class AnswerSheetQuiz(string title, QuizType type) : BaseQuiz(title, type)
    {
        public AnswerSheetQuizAttachments Attachments { get; private set; }
        public List<AnswerSheetQuestion> Questions { get; private set; }

        public void AddQuestions(short count, AnswerSheetQuestionChoices choices)
        {
            List<AnswerSheetQuestion> questions = new(count);

            questions.ForEach(question => question.SetChoices(choices));

            Questions.AddRange(questions);
        }

        public void AddQuestion(AnswerSheetQuestion question) => Questions.Add(Check.NotNull(question, nameof(question)));

        public void RemoveQuestion(AnswerSheetQuestion question) => Questions.Remove(Check.NotNull(question, nameof(question)));
    }
}
