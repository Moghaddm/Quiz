using NovinQuiz.Enums.Questions.CustomQuestions;
using NovinQuiz.Modules.Questions.CustomQuestions.Services;
using NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects;
using NovinQuiz.Modules.Quizzes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions
{
    public sealed class Blank(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        CustomQuestionAttachments? attachments,
        float score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz,
        List<BlankAnswerSection> answers
        ) : BaseCustomQuestion(text, difficultyStatus, type, attachments, score, timeLimit, showGuideInResultPage, showTipsInQuiz, quiz)
    {
        public List<BlankAnswerSection> Answers { get; private set; } = CustomQuestionManagerService.CheckBlankAnswerSectionsValid(answers, text);
    }
}
