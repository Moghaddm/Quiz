using NovinQuiz.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace NovinQuiz.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NovinQuizController : AbpControllerBase
{
    protected NovinQuizController()
    {
        LocalizationResource = typeof(NovinQuizResource);
    }
}
