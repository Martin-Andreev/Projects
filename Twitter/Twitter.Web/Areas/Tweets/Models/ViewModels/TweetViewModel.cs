namespace Twitter.Web.Areas.Tweets.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Twitter.Models;
    using Users.Models.ViewModels;

    public class TweetViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        public DateTime PostedOn { get; set; }

        public UserViewModel Author { get; set; }

        public bool Favourited { get; set; }

        public int RetweetsCount { get; set; }

        public int FavouritesCount { get; set; }

        public int RepliesCount { get; set; }

        IEnumerable<TweetReplyViewModel> Replies { get; set; }

        public static Expression<Func<Tweet, TweetViewModel>> ToViewModel(User currentUser)
        {
            return tweet => new TweetViewModel
            {
                Id = tweet.Id,
                Content = tweet.Content,
                Url = tweet.Url,
                PostedOn = tweet.PostedOn,
                Author = new UserViewModel
                {
                    Username = tweet.Author.UserName,
                    Name = tweet.Author.Name,
                    ProfileImageData = tweet.Author.ProfileImageData
                },
                RetweetsCount = tweet.RetweetedBy.Count,
                Favourited = tweet.FavouritedBy.Any(u => u.Id == currentUser.Id),
                FavouritesCount = tweet.FavouritedBy.Count,
                RepliesCount = tweet.RetweetedBy.Count,
            };
        } 
    }
}