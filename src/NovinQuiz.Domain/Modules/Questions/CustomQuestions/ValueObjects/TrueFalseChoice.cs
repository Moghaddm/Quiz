using NovinQuiz.Enums.Questions.CustomQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects
{
    public class TrueFalseChoice(string text, ChoiceCorrectionStatus correctionStatus, CustomQuestionAttachments attachments) : Choice(text, attachments)
    {
        public ChoiceCorrectionStatus CorrectionStatus { get; private set; } = correctionStatus;
    }
}
