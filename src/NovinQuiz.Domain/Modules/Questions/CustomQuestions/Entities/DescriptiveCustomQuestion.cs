using NovinQuiz.Modules.Questions.CustomQuestions.Enums;
using NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects;
using NovinQuiz.Modules.Quizzes.AnswerSheetQuizzes.ValueObjects;
using NovinQuiz.Modules.Quizzes.CustomQuizzes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Entities
{
    public class DescriptiveCustomQuestion(CustomQuestionText text,
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
