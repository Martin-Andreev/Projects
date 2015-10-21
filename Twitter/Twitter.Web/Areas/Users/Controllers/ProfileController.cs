namespace Twitter.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Data.Interfaces;
    using Infrastructure;
    using Models.ViewModels;
    using Web.Controllers;

    public class ProfileController : BaseController
    {
        private const string JoinedOnDateFormat = "d MMM yyyy";

        public ProfileController(ITwitterData data, IUserIdProvider userIdProvider)
            : base(data, userIdProvider)
        {
        }

        // GET: Profile
        public ActionResult Show(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = this.User.Identity.Name;
            }

            //var wantedUser = this.Data
            //    .Users
            //    .GetByUsername(username)
            //    .Project()
            //    .To<UserViewModel>()
            //    .FirstOrDefault();

            string currentUserId = this.UserIdProvider.GetUserId();
            var currentUser = this.Data.Users.Find(currentUserId);
            var wantedUser = this.Data
               .Users
               .GetByUsername(username)
               .Select(UserViewModel.ToViewModel(currentUser))
               .FirstOrDefault();

            if (wantedUser == null)
            {
                return HttpNotFound();
            }

            wantedUser = this.CheckForEmptyImages(wantedUser);
            wantedUser.JoinedOnFormated = wantedUser.JoinedOn.ToString(JoinedOnDateFormat);

            return this.View(wantedUser);
        }

        public ActionResult Edit()
        {
            return this.View();
        }

        public ActionResult ChangePassword()
        {
            return null;
        }
    }
}