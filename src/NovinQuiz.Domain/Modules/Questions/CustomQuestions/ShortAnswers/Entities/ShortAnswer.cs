using NovinQuiz.Modules.Questions.CustomQuestions.Common.Entities;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.Enums;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.ValueObjects;
using NovinQuiz.Modules.Questions.CustomQuestions.ShortAnswers.Services;
using NovinQuiz.Modules.Quizzes.AnswerSheetQuizzes.ValueObjects;
using NovinQuiz.Modules.Quizzes.CustomQuizzes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ShortAnswers.Entities
{
    public class ShortAnswer(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        AnswerSheetQuizAttachments? attachments,
        float score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz,
        List<string> answers
        ) : CustomQuestion(text, difficultyStatus, type, attachments, score, timeLimit, showGuideInResultPage, showTipsInQuiz, quiz)
    {
        public List<string> Answers { get; private set; } = new ShortAnswerQuestionManagerService().CheckAnswersValid(answers);
        public void SetAnswers(List<string> answers) => Answers = new ShortAnswerQuestionManagerService().CheckAnswersValid(answers);
    }
}
