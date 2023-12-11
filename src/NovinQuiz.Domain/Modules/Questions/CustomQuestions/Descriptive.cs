using NovinQuiz.Enums.Questions.CustomQuestions;
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
    public sealed class Descriptive(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        CustomQuestionAttachments? attachments,
        float score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz,
        ResponseMethodsDescriptiveQuestions responseMethods
        ) : BaseCustomQuestion(text, difficultyStatus, type, attachments, score, timeLimit, showGuideInResultPage, showTipsInQuiz, quiz)
    {
        public ResponseMethodsDescriptiveQuestions ResponseMethods { get; private set; } = responseMethods;
        public void UpdateResponseMethods(ResponseMethodsDescriptiveQuestions responseMethods)
            => ResponseMethods = Check.NotNull(responseMethods, nameof(responseMethods));
    }
}
