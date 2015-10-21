namespace Twitter.Data.Interfaces
{
    using System;
    using System.Data.Entity;
    using Models;

    public interface ITwitterContext : IDisposable
    {
        IDbSet<Tweet> Tweets { get; }

        IDbSet<TweetReply> TweetReplies { get; }

        IDbSet<Report> Reports { get; }

        IDbSet<Notification> Notifications { get; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
