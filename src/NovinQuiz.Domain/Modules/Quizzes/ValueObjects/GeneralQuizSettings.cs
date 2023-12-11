using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Volo.Abp.Http.MimeTypes;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public record struct GeneralQuizSettings(bool ShowStatisticsAfterEndQuiz, bool DisplayQuizResultPageAfterEnd, bool PlayAudioMultipleTimesAccess);
}
