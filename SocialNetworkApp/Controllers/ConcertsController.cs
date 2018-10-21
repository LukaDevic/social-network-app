using Microsoft.AspNet.Identity;
using SocialNetworkApp.Models;
using SocialNetworkApp.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace SocialNetworkApp.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConcertsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var concerts = _context.Concerts
                .Where(c => c.ArtistId == userId && c.DateTime > DateTime.Now)
                .Include(c => c.Genre)
                .ToList();

            return View(concerts);
        }

        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var concerts = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Concert)
                .Include(c => c.Artist)
                .Include(c => c.Genre)
                .ToList();

            var viewModel = new ConcertsViewModel()
            {
                UpcomingConcerts = concerts,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Concersts I'm attending"
            };

            return View("Concerts", viewModel);
        }


        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ConcertFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConcertFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }


            var concert = new Concert
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _context.Concerts.Add(concert);
            _context.SaveChanges();

            return RedirectToAction("Mine", "Home");
        }
    }
}