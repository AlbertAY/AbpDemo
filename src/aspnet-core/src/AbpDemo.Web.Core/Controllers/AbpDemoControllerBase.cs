using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AbpDemo.Controllers
{
    public abstract class AbpDemoControllerBase: AbpController
    {
        protected AbpDemoControllerBase()
        {
            LocalizationSourceName = AbpDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
