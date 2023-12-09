using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects
{
    public record struct ResponseMethodsDescriptiveQuestions(bool CanInsertText, bool CanRecordAudio, bool CanSendFile, bool CanSendPhoto, bool CanSendVideo);
}
