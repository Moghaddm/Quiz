using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public class ParticipatePeriod
    {
        public DateOnly StartPeriodDate { get; private set; }
        public DateOnly StartPeriodTime { get; private set; }
        public DateOnly EndPeriodDate { get; private set; }
        public DateOnly EndPeriodTime { get; private set; }


    }
}
