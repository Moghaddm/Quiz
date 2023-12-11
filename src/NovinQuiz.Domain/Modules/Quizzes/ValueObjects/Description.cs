using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public record struct Description(string startQuizDescription, string endQuizDescription)
    {
        public string StartQuizDescription { get; private set; } = Check.NotNullOrEmpty(startQuizDescription, nameof(startQuizDescription));
        public string EndQuizDescription { get; private set; } = Check.NotNullOrEmpty(endQuizDescription, nameof(endQuizDescription));
    }
}
