namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        private ICollection<TweetReply> replies;
        private ICollection<User> favouritedBy;
        private ICollection<User> retweetedBy;

        public Tweet()
        {
            this.replies = new HashSet<TweetReply>();
            this.favouritedBy = new HashSet<User>();
            this.retweetedBy = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Content { get; set; }

        [Required]
        public string Url { get; set; }

        public string Photo { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public string WallOwnerId { get; set; }

        public virtual User WallOwner { get; set; }

        public virtual ICollection<TweetReply> Comments
        {
            get { return this.replies; }
            set { this.replies = value; }
        }

        public virtual ICollection<User> FavouritedBy
        {
            get { return this.favouritedBy; }
            set { this.favouritedBy = value; }
        }

        public virtual ICollection<User> RetweetedBy
        {
            get { return this.retweetedBy; }
            set { this.retweetedBy = value; }
        }
    }
}
