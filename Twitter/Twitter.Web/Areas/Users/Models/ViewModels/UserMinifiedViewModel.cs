namespace Twitter.Web.Areas.Users.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Infrastructure.Mapping;
    using Twitter.Models;

    public class UserMinifiedViewModel : BaseUserViewModel, IMapFrom<User>
    {
        public static Expression<Func<User, UserMinifiedViewModel>> ToViewModel()
        {
            return user => new UserMinifiedViewModel
            {
                Id = user.Id,
                Username = user.UserName,
                Name = user.Name,
                ProfileImageData = user.ProfileImageData
            };
        } 
    }
}