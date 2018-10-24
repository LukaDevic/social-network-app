using SocialNetworkApp.Models;
using SocialNetworkApp.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace SocialNetworkApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(string query = null)
        {
            var upcomingConcerts = _context.Concerts
                .Include(c => c.Artist)
                .Include(g => g.Genre)
                .Where(c => c.DateTime > DateTime.Now && !c.IsCanceled);

            if (!String.IsNullOrWhiteSpace(query))
            {
                upcomingConcerts = upcomingConcerts
                    .Where(c =>
                             c.Artist.Name.Contains(query) ||
                             c.Genre.Name.Contains(query) ||
                             c.Venue.Contains(query));
            }

            var viewModel = new ConcertsViewModel
            {
                UpcomingConcerts = upcomingConcerts,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Concerts",
                SearchTerm = query

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