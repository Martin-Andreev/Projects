namespace Twitter.Data.Data
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Interfaces.Repositories;
    using Models;
    using Repositories;

    public class TwitterData : ITwitterData
    {
        private ITwitterContext context;
        private IDictionary<Type, object> repositories;

        public TwitterData(ITwitterContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IUsersRepository Users
        {
            get { return this.GetRepository<User>() as UsersRepository; }
        }

        public IRepository<Tweet> Tweets
        {
            get { return this.GetRepository<Tweet>(); }
        }

        public IRepository<TweetReply> TweetReplies
        {
            get { return this.GetRepository<TweetReply>(); }
        }

        public IRepository<Report> Reports
        {
            get { return this.GetRepository<Report>(); }
        }

        public IRepository<Notification> Notifications
        {
            get { return this.GetRepository<Notification>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(GenericRepository<T>);

                if (typeof(T).IsAssignableFrom(typeof(User)))
                {
                    typeOfRepository = typeof(UsersRepository);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeOfRepository, this.context));
            }

            IRepository<T> repository = this.repositories[typeOfModel] as IRepository<T>;

            return repository;
        }
    }
}
