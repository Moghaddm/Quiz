using NovinQuiz.Modules.Questions.CustomQuestions.Common.Entities;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.Enums;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.Services;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.ValueObjects;
using NovinQuiz.Modules.Quizzes.AnswerSheetQuizzes.ValueObjects;
using NovinQuiz.Modules.Quizzes.CustomQuizzes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinQuiz.Modules.Questions.CustomQuestions.TrueFalses.Entities
{
    public class TrueFalse(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        AnswerSheetQuizAttachments? attachments,
        float score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz,
        List<QuestionChoice> choices
        ) : CustomQuestion(text, difficultyStatus, type, attachments, score, timeLimit, showGuideInResultPage, showTipsInQuiz, quiz)
    {
        public List<QuestionChoice> Choices { get; private set; } = new QuestionChoiceManagerService().CheckQuestionChoicesValid(choices);
        public void SetChoices(List<QuestionChoice> choices) => new QuestionChoiceManagerService().CheckQuestionChoicesValid(choices);
    }
}
