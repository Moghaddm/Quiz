using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Blank.ValueObjects
{
    public record struct BlankAnswerSections(short StartIndex, short EndIndex);
}
