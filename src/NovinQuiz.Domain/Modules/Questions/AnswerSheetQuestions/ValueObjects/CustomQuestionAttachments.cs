using NovinQuiz.Modules.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Questions.AnswerSheetQuestions.ValueObjects
{
    public record CustomQuestionAttachments
    {
        public CustomQuestionAttachments(Attachment? photo, Attachment? recordAudio) => (Photo, RecordAudio) = (photo, recordAudio);

        public Attachment? Photo { get; private set; }
        public void SetPhoto(Attachment? photo) => Photo = photo;

        public Attachment? RecordAudio { get; private set; } 
        public void SetRecordAudio(Attachment? recordAudio) => RecordAudio = recordAudio;
    }
}
