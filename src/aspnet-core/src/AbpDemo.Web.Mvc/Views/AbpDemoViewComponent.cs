using Abp.AspNetCore.Mvc.ViewComponents;

namespace AbpDemo.Web.Views
{
    public abstract class AbpDemoViewComponent : AbpViewComponent
    {
        protected AbpDemoViewComponent()
        {
            LocalizationSourceName = AbpDemoConsts.LocalizationSourceName;
        }
    }
}
