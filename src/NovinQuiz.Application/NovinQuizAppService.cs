using System;
using System.Collections.Generic;
using System.Text;
using NovinQuiz.Localization;
using Volo.Abp.Application.Services;

namespace NovinQuiz;

/* Inherit your application services from this class.
 */
public abstract class NovinQuizAppService : ApplicationService
{
    protected NovinQuizAppService()
    {
        LocalizationResource = typeof(NovinQuizResource);
    }
}
