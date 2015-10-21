namespace Twitter.Web.Areas.Notifications.Models
{
    using System;
    using Infrastructure.Mapping;
    using Twitter.Models;
    using Users.Models.ViewModels;

    public class NotificationViewModel : IMapFrom<Notification>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public bool Seen { get; set; }

        public UserViewModel Reciever { get; set; }
    }
}