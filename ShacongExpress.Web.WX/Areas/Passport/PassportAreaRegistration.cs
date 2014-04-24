using System.Web.Mvc;

namespace ShacongExpress.Web.WX.Areas.Passport
{
    public class PassportAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Passport";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Passport_default",
                "Passport/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
