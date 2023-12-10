using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Questions.CustomQuestions.Common.Exceptions
{
    public class QuestionChoicesCountCannotBeMoreThanEightException(string code) : BusinessException(code)
    {

    }
}
