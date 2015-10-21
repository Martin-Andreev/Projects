namespace Twitter.Data.Data
{
    using System.Data.Entity;
    using Interfaces;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class TwitterContext : IdentityDbContext, ITwitterContext
    {
        public TwitterContext()
            : base("TwitterContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<TwitterContext, Configuration>());
        }

        public IDbSet<Tweet> Tweets { get; set; }

        public IDbSet<TweetReply> TweetReplies { get; set; }
        
        public IDbSet<Report> Reports { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public static TwitterContext Create()
        {
            return new TwitterContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tweet>()
                .HasRequired(t => t.Author)
                .WithMany(a => a.Tweets)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tweet>()
                .HasRequired(t => t.WallOwner)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany()
                .Map(uf =>
                {
                    uf.MapLeftKey("UserId");
                    uf.MapRightKey("FollowerId");
                    uf.ToTable("UsersFollowers");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Following)
                .WithMany()
                .Map(uf =>
                {
                    uf.MapLeftKey("UserId");
                    uf.MapRightKey("FollowingId");
                    uf.ToTable("UsersFollowing");
                });

            modelBuilder.Entity<Tweet>()
                .HasMany(t => t.FavouritedBy)
                .WithMany()
                .Map(uf =>
                {
                    uf.MapLeftKey("FavouriteTweetId");
                    uf.MapRightKey("UserId");
                    uf.ToTable("FavouriteTweetsUsers");
                });

            modelBuilder.Entity<Tweet>()
               .HasMany(t => t.RetweetedBy)
               .WithMany()
               .Map(uf =>
               {
                   uf.MapLeftKey("RetweetedTweetId");
                   uf.MapRightKey("UserId");
                   uf.ToTable("RetweetsUsers");
               });


            base.OnModelCreating(modelBuilder);
        }
    }

}
