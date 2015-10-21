namespace Twitter.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Interfaces;
    using Infrastructure;

    public class PhotosController : BaseController
    {
        public PhotosController(ITwitterData data, IUserIdProvider userIdProvider)
            : base(data, userIdProvider)
        {
        }


        // GET: Photos
        public ActionResult Index()
        {
            return null;
        }
    }
}