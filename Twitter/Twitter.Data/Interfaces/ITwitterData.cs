namespace Twitter.Data.Interfaces
{
    using Models;
    using Repositories;

    public interface ITwitterData
    {
        IUsersRepository Users { get; }

        IRepository<Tweet> Tweets { get; }
        
        IRepository<TweetReply> TweetReplies { get; }

        IRepository<Report> Reports { get; }

        IRepository<Notification> Notifications { get; }

        int SaveChanges();
    }
}
