namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        public int Id { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime SentOn { get; set; }

        public bool Seen { get; set; }

        [Required]
        public string RecieverId { get; set; }

        public virtual User Reciever { get; set; }
    }
}
