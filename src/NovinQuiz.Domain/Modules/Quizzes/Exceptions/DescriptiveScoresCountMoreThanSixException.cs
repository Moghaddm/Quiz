using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Quizzes.Exceptions
{
    public sealed class DescriptiveScoresCountMoreThanSixException(string code) : BusinessException(code)
    {

    }
}
