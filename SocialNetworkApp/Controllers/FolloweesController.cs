using Microsoft.AspNet.Identity;
using SocialNetworkApp.Core;
using System.Web.Mvc;

namespace SocialNetworkApp.Controllers
{
    public class FolloweesController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public FolloweesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var artists = _unitOfWork.Users.GetArtistsFollowedBy(userId);

            return View(artists);
        }
    }
}