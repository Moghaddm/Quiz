using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public class Description : ValueObject
    {
        public string StartQuizDescription { get; private set; }
        public string EndQuizDescription { get; private set; }

        public Description(string startQuizDescription, string endQuizDescription)
        {
            
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
