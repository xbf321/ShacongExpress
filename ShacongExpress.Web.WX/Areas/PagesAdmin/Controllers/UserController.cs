using System.Web.Mvc;

using ShacongExpress.Service;
using ShacongExpress.Models;
using ShacongExpress.Common;

namespace ShacongExpress.Web.WX.Areas.PagesAdmin.Controllers
{
    public class UserController : Controller
    {
        public ActionResult BaseInfoList()
        {
            var list = UserService.BaseInfoList(new SearchSetting()
            {
                PageIndex = SERequest.GetQueryInt("page", 1)
            });

            ViewBag.List = list;

            return View();
        }

    }
}
