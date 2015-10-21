using System.Web.Mvc;

namespace Twitter.Web.Areas.Notifications
{
    public class NotificationsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Notifications";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Notifications_default",
                "Notifications/{controller}/{action}/{username}",
                new { action = "Index", username = UrlParameter.Optional }
            );
        }
    }
}