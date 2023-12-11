using NovinQuiz.Enums.Questions.CustomQuestions;
using NovinQuiz.Modules.Questions.CustomQuestions.Services;
using NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects;
using NovinQuiz.Modules.Quizzes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinQuiz.Modules.Questions.CustomQuestions
{
    public sealed class Pluggable(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        CustomQuestionAttachments? attachments,
        float score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz,
        List<PluggableItem> items
        ) : BaseCustomQuestion(text, difficultyStatus, type, attachments, score, timeLimit, showGuideInResultPage, showTipsInQuiz, quiz)
    {
        public List<PluggableItem> Items { get; private set; } = CustomQuestionManagerService.CheckPluggableItemsValid(items);
        public void SetItems(List<PluggableItem> items) => CustomQuestionManagerService.CheckPluggableItemsValid(items);
    }
}
