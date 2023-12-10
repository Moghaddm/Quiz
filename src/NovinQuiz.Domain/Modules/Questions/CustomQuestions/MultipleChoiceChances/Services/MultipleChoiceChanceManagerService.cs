using NovinQuiz.Modules.Questions.CustomQuestions.MultipleChoiceChances.Exceptions;
using NovinQuiz.Modules.Questions.CustomQuestions.MultipleChoiceChances.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovinQuiz.Modules.Questions.CustomQuestions.MultipleChoiceChances.Services
{
    public class MultipleChoiceChanceManagerService
    {
        public List<MultipleChoiceChanceItem> CheckMultipleChoiceChancesValid(List<MultipleChoiceChanceItem> items, float score)
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
    }
}
