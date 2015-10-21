namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TweetReply
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Content { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public int TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }
    }
}
