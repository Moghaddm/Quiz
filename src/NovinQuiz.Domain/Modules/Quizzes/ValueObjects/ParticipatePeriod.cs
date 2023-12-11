using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public sealed record ParticipatePeriod(DateOnly StartPeriodDate, TimeOnly StartPeriodTime, DateOnly EndPeriodDate, TimeOnly EndPeriodTime);
}
