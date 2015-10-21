namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int TweetId { get; set; }

        //[ForeignKey("TweetId")]
        public virtual Tweet Tweet { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string UserId { get; set; }

        //[ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
