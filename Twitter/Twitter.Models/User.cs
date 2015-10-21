namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Enums;
    using Microsoft.AspNet.Identity;

    public class User : IdentityUser
    {
        private ICollection<Tweet> tweets;
        private ICollection<Tweet> retweets;
        private ICollection<Tweet> favouriteTweets;
        private ICollection<User> followers;
        private ICollection<User> following;
        private ICollection<Notification> notifications;


        public User()
        {
            this.followers = new HashSet<User>();
            this.following = new HashSet<User>();
            this.tweets = new HashSet<Tweet>();
            this.favouriteTweets = new HashSet<Tweet>();
            this.retweets = new HashSet<Tweet>();
            this.notifications = new HashSet<Notification>();
        }

        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        //[Required]
        //[Index(IsUnique = true)]
        //public string Username { get; set; }

        public string ProfileImageData { get; set; }

        public string CoverImageData { get; set; }

        public string Location { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public DateTime? Birthday { get; set; }

        [Required]
        public DateTime JoinedOn { get; set; }

        public Gender? Gender { get; set; }

        public virtual ICollection<User> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        public virtual ICollection<User> Following
        {
            get { return this.following; }
            set { this.following = value; }
        }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }

        public virtual ICollection<Tweet> FavouriteTweets
        {
            get { return this.favouriteTweets; }
            set { this.favouriteTweets = value; }
        }

        public virtual ICollection<Tweet> Retweets
        {
            get { return this.retweets; }
            set { this.retweets = value; }
        }

        public virtual ICollection<Notification> Notifications
        {
            get { return this.notifications; }
            set { this.notifications = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}
