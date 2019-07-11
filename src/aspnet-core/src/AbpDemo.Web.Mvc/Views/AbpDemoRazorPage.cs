using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace AbpDemo.Web.Views
{
    public abstract class AbpDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AbpDemoRazorPage()
        {
            LocalizationSourceName = AbpDemoConsts.LocalizationSourceName;
        }
    }
}
