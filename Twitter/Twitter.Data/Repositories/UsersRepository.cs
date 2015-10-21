namespace Twitter.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using Interfaces.Repositories;
    using Models;

    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(DbContext context) 
            : base(context)
        {
        }

        public IQueryable<User> GetByUsername(string username)
        {
            return this.All().Where(u => u.UserName == username);
        }
    }
}
