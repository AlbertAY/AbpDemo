using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AbpDemo.Controllers;

namespace AbpDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AbpDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
