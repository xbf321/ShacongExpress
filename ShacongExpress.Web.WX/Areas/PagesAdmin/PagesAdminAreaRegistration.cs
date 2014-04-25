using System.Web.Mvc;

namespace ShacongExpress.Web.WX.Areas.PagesAdmin
{
    public class PagesAdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "PagesAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "PagesAdmin_default",
                "PagesAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
