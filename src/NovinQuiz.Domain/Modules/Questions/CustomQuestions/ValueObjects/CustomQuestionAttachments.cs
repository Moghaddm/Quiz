using NovinQuiz.Modules.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects
{
    public sealed class CustomQuestionAttachments(Attachment? photo, Attachment? recordAudio) : ValueObject
    {
        public Attachment? Photo { get; private set; } = photo;
        public void SetPhoto(Attachment? photo) => Photo = photo;

        public Attachment? RecordAudio { get; private set; } = recordAudio;
        public void SetRecordAudio(Attachment? recordAudio) => RecordAudio = recordAudio;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Photo;
            yield return RecordAudio;
        }
    }
}
