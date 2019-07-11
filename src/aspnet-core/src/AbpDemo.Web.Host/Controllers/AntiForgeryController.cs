using Microsoft.AspNetCore.Antiforgery;
using AbpDemo.Controllers;

namespace AbpDemo.Web.Host.Controllers
{
    public class AntiForgeryController : AbpDemoControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
