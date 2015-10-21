namespace Twitter.Data.Interfaces.Repositories
{
    using System.Linq;
    using Models;

    public interface IUsersRepository : IRepository<User>
    {
        IQueryable<User> GetByUsername(string username);
    }
}
