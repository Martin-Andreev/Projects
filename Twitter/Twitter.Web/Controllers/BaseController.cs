namespace Twitter.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Users.Models.ViewModels;
    using Data.Interfaces;
    using Infrastructure;
    using Twitter.Models;
    using Twitter.Models.Enums;

    public class BaseController : Controller
    {
        private const string DefaultFemaleImagePath = "~/Content/Images/default-female.jpg";
        private const string DefaultMaleImagePath = "~/Content/Images/default-male.png";
        private const string DefaultCoverImagePath = "~/Content/Images/default-cover.jpg";

        public BaseController(ITwitterData data, IUserIdProvider userIdProvider)
        {
            this.Data = data;
            this.UserIdProvider = userIdProvider;
        }

        protected ITwitterData Data { get; set; }

        protected IUserIdProvider UserIdProvider { get; set; }

        protected UserViewModel CheckForEmptyImages(UserViewModel user)
        {
            if (user.ProfileImageData == null)
            {
                if (user.Gender == Gender.Female.ToString() || user.Gender == Gender.Other.ToString())
                {
                    user.ProfileImageData = DefaultFemaleImagePath;
                }
                else
                {
                    user.ProfileImageData = DefaultMaleImagePath;
                }
            }

            if (user.CoverImageData == null)
            {
                user.CoverImageData = DefaultCoverImagePath;
            }

            return user;
        }

        protected string PutDefaultProfieImage(string gender)
        {
            string photo;
            if (gender == Gender.Female.ToString() || gender == Gender.Other.ToString())
            {
                photo = DefaultFemaleImagePath;
            }
            else
            {
                photo = DefaultMaleImagePath;
            }

            return photo;
        }

        protected string PutDefaultCoverImage()
        {
            return DefaultCoverImagePath;
        }
    }
}