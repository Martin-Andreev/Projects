namespace Twitter.Web.Areas.Tweets.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Interfaces;
    using Infrastructure;
    using Models.ViewModels;
    using Web.Controllers;

    public class TweetsController : BaseController
    {
        public TweetsController(ITwitterData data, IUserIdProvider userIdProvider)
            : base(data, userIdProvider)
        {
        }

        public ActionResult Index()
        {
            return null;
        }

        [ChildActionOnly]
        public ActionResult GetUserTweets(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = this.User.Identity.Name;
            }

            string currentUserId = this.UserIdProvider.GetUserId();
            var currentUser = this.Data.Users.Find(currentUserId);
            var tweets = this.Data
                .Tweets
                .All()
                .Where(t => t.Author.UserName == username)
                .Select(TweetViewModel.ToViewModel(currentUser));

            return this.PartialView("~/Views/Shared/_TweetsPartial.cshtml", tweets);
        }
    }
}