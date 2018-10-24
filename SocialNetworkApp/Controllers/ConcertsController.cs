﻿using Microsoft.AspNet.Identity;
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


        public ActionResult Details(int id)
        {
            var concert = _context.Concerts
                .Include(c => c.Artist)
                .Include(c => c.Genre)
                .SingleOrDefault(c => c.Id == id);

            if (concert == null)
                return HttpNotFound();

            var viewModel = new ConcertDetailsViewModel
            {
                Concert = concert
            };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.IsAttending = _context.Attendances
                    .Any(a => a.AttendeeId == userId && a.ConcertId == concert.Id);

                viewModel.IsFollowing = _context.Followings
                    .Any(f => f.FollowerId == userId && f.FolloweeId == concert.ArtistId);
            }

            return View(viewModel);
        }



        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var concerts = _context.Concerts
                .Where(c =>
                  c.ArtistId == userId &&
                  c.DateTime > DateTime.Now &&
                  !c.IsCanceled)
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

            var attendances = _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Concert.DateTime > DateTime.Now)
                .ToList()
                .ToLookup(a => a.ConcertId);

            var viewModel = new ConcertsViewModel()
            {
                UpcomingConcerts = concerts,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Concersts I'm attending",
                Attendances = attendances
            };

            return View("Concerts", viewModel);
        }

        [HttpPost]
        public ActionResult Search(ConcertsViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
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
            var concert = _context.Concerts
                .Include(c => c.Attendances.Select(a => a.Attendee))
                .Single(c => c.Id == viewModel.Id && c.ArtistId == userId);


            concert.Modify(viewModel.GetDateTime(), viewModel.Venue, viewModel.Genre);

            _context.SaveChanges();

            return RedirectToAction("Mine", "Concerts");
        }
    }
}