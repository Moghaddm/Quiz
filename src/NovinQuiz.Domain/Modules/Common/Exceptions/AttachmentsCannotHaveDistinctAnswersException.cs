using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NovinQuiz.Modules.Common.Exceptions
{
    public sealed class AttachmentsCannotBeRepeatOnAnswersException(string code) : BusinessException(code)
    {

    }
}
