using NovinQuiz.Modules.Questions.CustomQuestions.Common.Entities;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.Enums;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.ValueObjects;
using NovinQuiz.Modules.Questions.CustomQuestions.Descriptives.ValueObjects;
using NovinQuiz.Modules.Quizzes.AnswerSheetQuizzes.ValueObjects;
using NovinQuiz.Modules.Quizzes.CustomQuizzes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Descriptives.Entities
{
    public class Descriptive(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        AnswerSheetQuizAttachments? attachments,
        float score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz,
        ResponseMethodsDescriptiveQuestions responseMethods
        ) : CustomQuestion(text, difficultyStatus, type, attachments, score, timeLimit, showGuideInResultPage, showTipsInQuiz, quiz)
    {
        public ResponseMethodsDescriptiveQuestions ResponseMethods { get; private set; } = responseMethods;
        public void UpdateResponseMethods(ResponseMethodsDescriptiveQuestions responseMethods)
            => ResponseMethods = Check.NotNull(responseMethods, nameof(responseMethods));
    }
}
