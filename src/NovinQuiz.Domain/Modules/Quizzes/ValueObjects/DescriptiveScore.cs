using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public class DescriptiveScore : ValueObject
    {
        public byte ScorePeriod { get; private set; }
        public string Description { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
