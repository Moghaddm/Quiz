using NovinQuiz.Enums.Questions.CustomQuestions.Pluggable;
using NovinQuiz.Modules.Common.Exceptions;
using NovinQuiz.Modules.Questions.CustomQuestions.Exceptions;
using NovinQuiz.Modules.Questions.CustomQuestions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Services
{
    public sealed class CustomQuestionManagerService : DomainService
    {
        public static List<BlankAnswerSections> CheckBlankAnswerSectionsValid(List<BlankAnswerSections> answers, CustomQuestionText text)
        {
            Check.NotNull(answers, nameof(answers));

            if (answers.Distinct().Count() != answers.Count)
                throw new BlankAnswerSectionsCannotRepeatException("Domain:BlankAnswerSectionsCannotRepeat");

            answers.ForEach(a =>
            {
                if (a.EndIndex - a.StartIndex == text.Value.Length - 1)
                    throw new BlankAnswerSectionCannotHaveAllTheTextInQuestionException("Domain:BlankAnswerSectionCannotHaveAllTheTextInQuestion");
            });

            return answers;
        }

        public static List<MultipleChoiceChanceItem> CheckMultipleChoiceChancesAnswersValid(List<MultipleChoiceChanceItem> items, float score)
        {
            int sumScores = items.Sum(i => i.Score);
            int negativePoints = items.Sum(i => i.NegativePoint);

            if (items.Count < 2)
                throw new MultipleChoiceChanceItemsCountCannotBeLessThanTwoException("Domain:MultipleChoiceChanceItemsCountCannotBeLessThanTwo");

            if (sumScores != score || negativePoints != score)
                throw new SumChoiceScoresMustBeEqualToQuestionScoreException("Domain:SumChoiceScoresMustBeEqualToQuestionScore");

            if (negativePoints != sumScores)
                throw new SumChoiceScoresMustBeEqualToSumChoicesNegativePointException("Domain:SumChoiceScoresMustBeEqualToSumChoicesNegativePoint")
                    .WithData("SumScores", sumScores)
                    .WithData("NegativePoints", negativePoints);

            return items;
        }

        public static List<PluggableQuestionAnswerItem> CheckPluggableItemsValid(List<PluggableQuestionAnswerItem> items)
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

                if (i.Second is not null && i.Second.Attachments is not null)
                    attachments.Add(i.Second.Attachments);
            });

            if (attachments.Distinct().Count() != attachments.Count)
                throw new AttachmentsCannotBeRepeatOnAnswersException("Domain:AttachmentsCannotHaveDistinctAnswers");

            return items;
        }

        public static List<string> CheckShortAnswerItemsValid(List<string> answerQuestions)
        {
            Check.Range(answerQuestions.Count, nameof(answerQuestions.Count), 1, 5);

            if (answerQuestions.Distinct().Count() != answerQuestions.Count)
                throw new ChoicesCannotHaveDistinctAnswersException("Domain:ChoicesCannotHaveDistinctAnswers");

            return answerQuestions;
        }
    }
}
