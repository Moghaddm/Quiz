using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public record ParticipatePeriod(DateOnly StartPeriodDate, DateOnly StartPeriodTime, DateOnly EndPeriodDate, DateOnly EndPeriodTime);
}
