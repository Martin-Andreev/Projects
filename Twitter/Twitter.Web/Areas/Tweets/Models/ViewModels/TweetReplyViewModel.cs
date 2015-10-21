namespace Twitter.Web.Areas.Tweets.Models.ViewModels
{
    using System;
    using Users.Models.ViewModels;

    public class TweetReplyViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        public DateTime PostedOn { get; set; }

        public UserViewModel Author { get; set; }

        public TweetViewModel Tweet { get; set; }
    }
}