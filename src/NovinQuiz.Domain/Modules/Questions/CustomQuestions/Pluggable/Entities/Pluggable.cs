using NovinQuiz.Modules.Questions.CustomQuestions.Common.Entities;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.Enums;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.ValueObjects;
using NovinQuiz.Modules.Questions.CustomQuestions.Pluggable.Services;
using NovinQuiz.Modules.Questions.CustomQuestions.Pluggable.ValueObjects;
using NovinQuiz.Modules.Quizzes.AnswerSheetQuizzes.ValueObjects;
using NovinQuiz.Modules.Quizzes.CustomQuizzes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Pluggable.Entities
{
    public class Pluggable(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        AnswerSheetQuizAttachments? attachments,
        float score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz,
        List<PluggableQuestionAnswerItem> items
        ) : CustomQuestion(text, difficultyStatus, type, attachments, score, timeLimit, showGuideInResultPage, showTipsInQuiz, quiz)
    {
        public List<PluggableQuestionAnswerItem> Items { get; private set; } = new PluggableQuestionManagerService().CheckPluggableItemsValid(items);
        public void SetItems(List<PluggableQuestionAnswerItem> items) => new PluggableQuestionManagerService().CheckPluggableItemsValid(items);
    }
}
