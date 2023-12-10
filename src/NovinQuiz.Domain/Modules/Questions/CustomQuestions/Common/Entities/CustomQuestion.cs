using NovinQuiz.Modules.Questions.CustomQuestions.Common.Enums;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.Services;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.ValueObjects;
using NovinQuiz.Modules.Quizzes.AnswerSheetQuizzes.ValueObjects;
using NovinQuiz.Modules.Quizzes.CustomQuizzes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Common.Entities
{
    public class CustomQuestion(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        AnswerSheetQuizAttachments? attachments,
        float score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz)
        : Entity<string>
    {
        public CustomQuestionText Text { get; private set; } = Check.NotNull(text, nameof(text));
        public QuestionDifficultyStatus DifficultyStatus { get; private set; } = difficultyStatus;
        public QuestionType Type { get; private set; } = type;
        public AnswerSheetQuizAttachments? Attachments { get; private set; } = attachments;

        private float _score = new QuestionCustomPropertiesManagerService().CheckCanSetQuestionScore(quiz, score);
        public float Score => _score;
        public void SetScore(CustomQuiz quiz, float score)
            => _score = new QuestionCustomPropertiesManagerService().CheckCanSetQuestionScore(quiz, score);

        public short? TimeLimit { get; set; } = timeLimit;  // according to minutes 
        public bool ShowGuideInResultPage { get; private set; } = showGuideInResultPage;
        public bool ShowTipsInQuiz { get; private set; } = showTipsInQuiz;

        public bool IsArchived { get; private set; } = false;
        public void Archive() => IsArchived = true;

        public void Update(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        AnswerSheetQuizAttachments? attachments,
        byte score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz)
        {
            Text = Check.NotNull(text, nameof(text));
            DifficultyStatus = difficultyStatus;
            Type = type;
            Attachments = attachments;
            SetScore(quiz, score);
            TimeLimit = timeLimit;
            ShowGuideInResultPage = showGuideInResultPage;
            ShowTipsInQuiz = showTipsInQuiz;
        }
    }
}
