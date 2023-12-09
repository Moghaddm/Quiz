using NovinQuiz.Modules.Quizzes.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Volo.Abp.Http.MimeTypes;

namespace NovinQuiz.Modules.Quizzes.ValueObjects
{
    public record struct GeneralQuizSettings
    {
        public bool ShowStatisticsAfterEndQuiz { get; private set; }
        public bool DisplayQuizResultPageAfterEnd { get; private set; }
        public bool PlayAudioMultipleTimesAccess { get; private set; }

        public void SetShowStatisticsAfterEndQuiz(bool showStatisticsAfterEndQuiz) => ShowStatisticsAfterEndQuiz = showStatisticsAfterEndQuiz;

        public void SetDisplayQuizResultPageAfterEnd(bool displayQuizResultPageAfterEnd) => DisplayQuizResultPageAfterEnd = displayQuizResultPageAfterEnd;

        public void SetPlayAudioMultipleTimesAccess(bool playAudioMultipleTimesAccess) => PlayAudioMultipleTimesAccess = playAudioMultipleTimesAccess;

        public static GeneralQuizSettings Create(bool showStatisticsAfterEndQuiz, bool displayQuizResultPageAfterEnd, bool playAudioMultipleTimesAccess)
            => new GeneralQuizSettings(showStatisticsAfterEndQuiz, displayQuizResultPageAfterEnd, playAudioMultipleTimesAccess);

        private GeneralQuizSettings(bool showStatisticsAfterEndQuiz, bool displayQuizResultPageAfterEnd, bool playAudioMultipleTimesAccess)
            => (ShowStatisticsAfterEndQuiz, DisplayQuizResultPageAfterEnd, PlayAudioMultipleTimesAccess)
            = (showStatisticsAfterEndQuiz, displayQuizResultPageAfterEnd, playAudioMultipleTimesAccess);
    }
}
