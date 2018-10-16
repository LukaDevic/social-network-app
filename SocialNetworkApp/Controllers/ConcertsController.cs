using Microsoft.AspNet.Identity;
using SocialNetworkApp.Models;
using SocialNetworkApp.ViewModels;
using System;
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
        public ActionResult Create(ConcertFormViewModel viewModel)
        {

            var concert = new Concert
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _context.Concerts.Add(concert);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}