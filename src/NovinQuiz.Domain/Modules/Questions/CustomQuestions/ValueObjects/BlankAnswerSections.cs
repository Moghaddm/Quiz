using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects
{
    public record struct BlankAnswerSections(short startIndex, short endIndex, string text)
    {
        public short StartIndex { get; private set; } = Check.Positive(startIndex, nameof(StartIndex));
        public short EndIndex { get; private set; } = (short)Check.Range(endIndex, nameof(endIndex), startIndex + 1, text.Length - 1);
    }
}
