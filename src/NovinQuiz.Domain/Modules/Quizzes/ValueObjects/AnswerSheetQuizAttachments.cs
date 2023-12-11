using NovinQuiz.Modules.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public sealed record AnswerSheetQuizAttachments
    {
        private IList<Attachment> _attachments;
        public IReadOnlyCollection<Attachment> Attachments => _attachments.AsReadOnly();

        public void AddAttachment(Attachment attachment) => _attachments.Add(Check.NotNull(attachment, nameof(attachment)));
        public void RemoveAttachment(Attachment attachment) => _attachments.Remove(Check.NotNull(attachment, nameof(attachment)));
    }
}
