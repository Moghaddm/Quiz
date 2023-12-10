using NovinQuiz.Modules.Questions.CustomQuestions.Common.Entities;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.Enums;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.ValueObjects;
using NovinQuiz.Modules.Questions.CustomQuestions.MultipleChoiceChances.Services;
using NovinQuiz.Modules.Questions.CustomQuestions.MultipleChoiceChances.ValueObjects;
using NovinQuiz.Modules.Quizzes.AnswerSheetQuizzes.ValueObjects;
using NovinQuiz.Modules.Quizzes.CustomQuizzes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinQuiz.Modules.Questions.CustomQuestions.MultipleChoiceChances.Entities
{
    public class MultipleChoiceChance(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        AnswerSheetQuizAttachments? attachments,
        float score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz,
        List<MultipleChoiceChanceItem> items
        ) : CustomQuestion(text, difficultyStatus, type, attachments, score, timeLimit, showGuideInResultPage, showTipsInQuiz, quiz)
    {
        public List<MultipleChoiceChanceItem> Choices { get; private set; } = new MultipleChoiceChanceManagerService().CheckMultipleChoiceChancesValid(items, score);
        public void SetChoices(List<MultipleChoiceChanceItem> items) => Choices = new MultipleChoiceChanceManagerService().CheckMultipleChoiceChancesValid(items, score);
    }
}
