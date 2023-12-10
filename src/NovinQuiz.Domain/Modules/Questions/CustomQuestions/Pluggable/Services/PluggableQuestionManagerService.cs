using NovinQuiz.Modules.Common.Exceptions;
using NovinQuiz.Modules.Questions.AnswerSheetQuestions.ValueObjects;
using NovinQuiz.Modules.Questions.CustomQuestions.Common.Exceptions;
using NovinQuiz.Modules.Questions.CustomQuestions.Pluggable.Enums;
using NovinQuiz.Modules.Questions.CustomQuestions.Pluggable.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Pluggable.Services
{
    public class PluggableQuestionManagerService
    {
        public List<PluggableQuestionAnswerItem> CheckPluggableItemsValid(List<PluggableQuestionAnswerItem> items)
        {
            if (items.Count(i => i.Type == PluggableQuestionItemType.Question) > 8
                || items.Count(i => i.Type == PluggableQuestionItemType.Answer) > 8)
                throw new QuestionChoicesCountCannotBeMoreThanEightException("Domain:QuestionChoicesCountCannotBeMoreThanEight");

            if (items.Where(i => i.Type == PluggableQuestionItemType.Question).Distinct().Count() != items.Count
                || items.Where(i => i.Type == PluggableQuestionItemType.Answer).Distinct().Count() != items.Count)
                throw new ChoicesCannotHaveDistinctAnswersException("Domain:ChoicesCannotHaveDistinctAnswers");

            var attachments = new List<CustomQuestionAttachments>();
            items.ForEach(i =>
            {
                if (i.First.Attachments is not null)
                    attachments.Add(i.First.Attachments);

                if (i.Second is not null && i.Second.Value.Attachments is not null)
                    attachments.Add(i.Second.Value.Attachments);
            });

            if (attachments.Distinct().Count() != attachments.Count)
                throw new AttachmentsCannotHaveDistinctAnswersException("Domain:AttachmentsCannotHaveDistinctAnswers");

            return items;
        }
    }
}
