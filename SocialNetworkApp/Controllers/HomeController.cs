using Microsoft.AspNet.Identity;
using SocialNetworkApp.Core;
using SocialNetworkApp.Core.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace SocialNetworkApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string query = null)
        {
            var upcomingConcerts = _unitOfWork.Concerts.GetUpcomingConcerts(query);

            var userId = User.Identity.GetUserId();
            var attendances = _unitOfWork.Attendances.GetFutureAttendances(userId)
                .ToLookup(a => a.ConcertId);

            var viewModel = new ConcertsViewModel
            {
                UpcomingConcerts = upcomingConcerts,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Concerts",
                SearchTerm = query,
                Attendances = attendances

            };
            return View("Concerts", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }


}