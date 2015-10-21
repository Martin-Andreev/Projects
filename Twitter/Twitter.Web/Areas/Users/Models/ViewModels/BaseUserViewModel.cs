namespace Twitter.Web.Areas.Users.Models.ViewModels
{
    public class BaseUserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string ProfileImageData { get; set; }

        public string CoverImageData { get; set; }
    }
}