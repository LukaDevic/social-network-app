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

        [Authorize]
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
                Genres = _context.Genres.ToList(),
                Heading = "Add a Concert"
            };

            return View("ConcertForm", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var concert = _context.Concerts.Single(c => c.Id == id && c.ArtistId == userId);

            var viewModel = new ConcertFormViewModel
            {
                Heading = "Edit a Concert",
                Id = concert.Id,
                Genres = _context.Genres.ToList(),
                Date = concert.DateTime.ToString("d MMM yyyy"),
                Time = concert.DateTime.ToString("HH:mm"),
                Genre = concert.GenreId,
                Venue = concert.Venue
            };

            return View("ConcertForm", viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConcertFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("ConcertForm", viewModel);
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

            return RedirectToAction("Mine", "Concerts");
        }



        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ConcertFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("ConcertForm", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var concert = _context.Concerts.Single(c => c.Id == viewModel.Id && c.ArtistId == userId);

            concert.Venue = viewModel.Venue;
            concert.DateTime = viewModel.GetDateTime();
            concert.GenreId = viewModel.Genre;

            _context.SaveChanges();

            return RedirectToAction("Mine", "Concerts");
        }
    }
}