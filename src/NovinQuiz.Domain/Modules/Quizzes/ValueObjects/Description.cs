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
    public record struct Description
    {
        public string StartQuizDescription { get; private set; }
        public string EndQuizDescription { get; private set; }

        public Description(string startQuizDescription, string endQuizDescription)
            => (StartQuizDescription, EndQuizDescription)
            = (Check.NotNullOrEmpty(startQuizDescription, nameof(startQuizDescription)),
                Check.NotNullOrEmpty(endQuizDescription, nameof(endQuizDescription)));

        public IEnumerable<object> GetAtomicValues()
        {
            yield return StartQuizDescription; yield return EndQuizDescription;
        }
    }
}
