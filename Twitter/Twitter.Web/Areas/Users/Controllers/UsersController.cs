namespace Twitter.Web.Areas.Users.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Data.Interfaces;
    using Infrastructure;
    using Models.ViewModels;
    using Twitter.Models;
    using Web.Controllers;

    public class UsersController : BaseController
    {
        public UsersController(ITwitterData data, IUserIdProvider userIdProvider)
            : base(data, userIdProvider)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFollowingUsersSuggestions()
        {
            string currentUserId = this.UserIdProvider.GetUserId();
            var currentUser = this.Data.Users.Find(currentUserId);

            //var users = this.Data
            //    .Users
            //    .All()
            //    .Where(u => !u.Followers.Contains(currentUser) &&
            //        u.Followers.Intersect(currentUser.Following).Any())
            //    .OrderBy(o => Guid.NewGuid())
            //    .Take(3)
            //    .Project()
            //    .To<UserMinifiedViewModel>();

            var users = this.Data
                .Users
                .All()
                .Where(u => u.Id != currentUserId)
                .OrderBy(o => o.Id)
                .Take(3)
                .Select(UserMinifiedViewModel.ToViewModel());

            IList<UserMinifiedViewModel> usersFormated = new List<UserMinifiedViewModel>();

            foreach (var user in users)
            {
                if (user.ProfileImageData == null)
                {
                    user.ProfileImageData = this.PutDefaultProfieImage(user.Gender);
                }

                usersFormated.Add(user);
            }

            return this.PartialView("~/Views/Shared/_FollowingSuggestionsPartial.cshtml", usersFormated);
        }
    }
}