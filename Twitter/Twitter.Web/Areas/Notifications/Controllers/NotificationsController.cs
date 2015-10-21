using System.Web.Mvc;

namespace Twitter.Web.Areas.Notifications.Controllers
{
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Data.Interfaces;
    using Infrastructure;
    using Models;
    using Web.Controllers;

    [Authorize]
    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwitterData data, IUserIdProvider userIdProvider)
            : base(data, userIdProvider)
        {
        }

        public ActionResult GetAll()
        {
            string currentUserId = this.UserIdProvider.GetUserId();
            var currentUser = this.Data.Users.Find(currentUserId);
            var notifications = this.Data
                .Notifications
                .All()
                .Where(n => n.RecieverId == currentUserId)
                .Project()
                .To<NotificationViewModel>();

            return View();
        }
    }
}