using NovinQuiz.Enums.Questions.CustomQuestions;
using NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects;
using NovinQuiz.Modules.Quizzes;
using NovinQuiz.Modules.Quizzes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace NovinQuiz.Modules.Questions.CustomQuestions
{
    public abstract class BaseCustomQuestion(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        CustomQuestionAttachments? attachments,
        float score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz,
        CustomQuiz quiz)
        : CreationAuditedAggregateRoot<string>
    {
        public CustomQuestionText Text { get; private set; } = Check.NotNull(text, nameof(text));
        public QuestionDifficultyStatus DifficultyStatus { get; private set; } = difficultyStatus;
        public QuestionType Type { get; private set; } = type;
        public CustomQuestionAttachments? Attachments { get; private set; } = attachments;
        private float _score;
        public float Score
        {
            get => _score;
            set => _score = QuestionPropertiesManagerService.CheckCanSetQuestionScore(quiz, score);
        }
        public short? TimeLimit { get; set; } = timeLimit;  // according to minutes 
        public bool ShowGuideInResultPage { get; private set; } = showGuideInResultPage;
        public bool ShowTipsInQuiz { get; private set; } = showTipsInQuiz;
        public bool IsArchived { get; private set; } = false;

        public void Archive() => IsArchived = true;

        public void Update(CustomQuestionText text,
        QuestionDifficultyStatus difficultyStatus,
        QuestionType type,
        CustomQuestionAttachments? attachments,
        byte score,
        short? timeLimit,
        bool showGuideInResultPage,
        bool showTipsInQuiz)
        {
            Text = Check.NotNull(text, nameof(text));
            DifficultyStatus = difficultyStatus;
            Type = type;
            Attachments = attachments;
            Score = score;
            TimeLimit = timeLimit;
            ShowGuideInResultPage = showGuideInResultPage;
            ShowTipsInQuiz = showTipsInQuiz;
        }
    }
}
