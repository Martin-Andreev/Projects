namespace Twitter.Web.Areas.Users.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Tweets.Models.ViewModels;
    using Twitter.Models;
    using Twitter.Models.Enums;

    public class UserViewModel : BaseUserViewModel
        //: IMapFrom<User>
    {
        public DateTime? Birthday { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public DateTime JoinedOn { get; set; }

        public string JoinedOnFormated { get; set; }

        public bool IsFollowed { get; set; }

        public int TweetsCount { get; set; }

        public int FavoriteTweetsCount { get; set; }

        public int FollowersCount { get; set; }

        public int FollowingCount { get; set; }

        public static Expression<Func<User, UserViewModel>> ToViewModel(User currentUser)
        {
            return user => new UserViewModel
            {
                Id = user.Id,
                Username = user.UserName,
                Name = user.Name,
                Description = user.Description,
                Gender = user.Gender.ToString(),
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Birthday = user.Birthday,
                JoinedOn = user.JoinedOn,
                ProfileImageData = user.ProfileImageData,
                CoverImageData = user.CoverImageData,
                IsFollowed = user.Followers.Any(f => f.Id == currentUser.Id),
                TweetsCount = user.Tweets.Count,
                FavoriteTweetsCount = user.FavouriteTweets.Count,
                FollowersCount = user.Followers.Count,
                FollowingCount = user.Following.Count
            };
        } 

        //public void CreateMappings(IConfiguration configuration)
        //{
        //    configuration.CreateMap<User, UserViewModel>()
        //        .ForMember(uvm => uvm.IsFollowed, options => options.MapFrom(u => u.Followers.Any(f => f.)))
        //}
    }
}