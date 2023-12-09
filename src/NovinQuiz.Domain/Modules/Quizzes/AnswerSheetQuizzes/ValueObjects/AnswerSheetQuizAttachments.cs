using NovinQuiz.Modules.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Quizzes.AnswerSheetQuizzes.ValueObjects
{
    public class AnswerSheetQuizAttachments : ValueObject
    {
        private List<Attachment> _attachments;
        public IReadOnlyCollection<Attachment> Attachments => _attachments.AsReadOnly();

        public void AddAttachment(Attachment attachment) => _attachments.Add(attachment);
        public void RemoveAttachment(Attachment attachment) => _attachments.Remove(attachment);

        public AnswerSheetQuizAttachments(List<Attachment> attachments)
            => _attachments = attachments;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return _attachments;
        }
    }
}
