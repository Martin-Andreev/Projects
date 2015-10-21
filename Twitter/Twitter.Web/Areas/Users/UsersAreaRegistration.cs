using System.Web.Mvc;

namespace Twitter.Web.Areas.Users
{
    public class UsersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Users";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
           // context.MapRoute(
           //    "Users_profile",
           //    "Users/{username}",
           //    new { controller = "Profile", action = "Show", username = UrlParameter.Optional }
           //);

            context.MapRoute(
                "Users_default",
                "Users/{controller}/{action}/{username}",
                new { action = "Index", username = UrlParameter.Optional }
            );
        }
    }
}