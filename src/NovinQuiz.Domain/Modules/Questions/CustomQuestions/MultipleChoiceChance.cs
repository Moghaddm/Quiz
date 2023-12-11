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
    public sealed class MultipleChoiceChance(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        CustomQuestionAttachments? attachments,
        float score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz,
        List<MultipleChoiceChanceItem> items
        ) : BaseCustomQuestion(text, difficultyStatus, type, attachments, score, timeLimit, showGuideInResultPage, showTipsInQuiz, quiz)
    {
        public List<MultipleChoiceChanceItem> Choices { get; private set; } = CustomQuestionManagerService.CheckMultipleChoiceChancesItemsValid(items, score);
        public void SetChoices(List<MultipleChoiceChanceItem> items) => Choices = CustomQuestionManagerService.CheckMultipleChoiceChancesItemsValid(items, score);
    }
}
