using System.Web.Mvc;

namespace Twitter.Web.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using Areas.Tweets.Models.ViewModels;
    using Data.Data;
    using Data.Interfaces;
    using Infrastructure;

    public class HomeController : BaseController
    {
        public const byte TweetsNumberOnPage = 10;

        public HomeController(ITwitterData data, IUserIdProvider userIdProvider)
            : base(data, userIdProvider)
        {
        }

        public ActionResult Index()
        {
            string currentUserId = this.UserIdProvider.GetUserId();
            var currentUser = this.Data.Users.Find(currentUserId);
            if (currentUser != null)
            {
                var tweets = this.Data
                    .Tweets
                    .All()
                    .Where(t => t.Author.Followers.Any(f => f.Id == currentUserId))
                    .OrderByDescending(t => t.PostedOn)
                    .Skip(0)
                    .Take(TweetsNumberOnPage)
                    .Select(TweetViewModel.ToViewModel(currentUser));

                return this.View(tweets);
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}