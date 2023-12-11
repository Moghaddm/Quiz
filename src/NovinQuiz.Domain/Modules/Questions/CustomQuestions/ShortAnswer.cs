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
    public sealed class ShortAnswer(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        CustomQuestionAttachments? attachments,
        float score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz,
        List<string> answers
        ) : BaseCustomQuestion(text, difficultyStatus, type, attachments, score, timeLimit, showGuideInResultPage, showTipsInQuiz, quiz)
    {
        public List<string> Answers { get; private set; } = CustomQuestionManagerService.CheckShortAnswerItemsValid(answers);
        public void SetAnswers(List<string> answers) => Answers = CustomQuestionManagerService.CheckShortAnswerItemsValid(answers);
    }
}
