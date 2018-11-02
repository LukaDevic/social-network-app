using SocialNetworkApp.Core.Models;
using SocialNetworkApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SocialNetworkApp.Persistence.Repositories
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly ApplicationDbContext _context;

        public ConcertRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Concert GetConcert(int concertId)
        {
            return _context.Concerts
                .Include(c => c.Artist)
                .Include(c => c.Genre)
                .SingleOrDefault(c => c.Id == concertId);
        }

        //luka
        public IEnumerable<Concert> GetUpcomingConcerts()
        {
            return _context.Concerts
                .Include(c => c.Artist)
                .Include(g => g.Genre)
                .Where(c => c.DateTime > DateTime.Now && !c.IsCanceled);
        }

        public IEnumerable<Concert> GetUpcomingConcertsByArtist(string artistId)
        {
            return _context.Concerts
                .Where(c =>
                  c.ArtistId == artistId &&
                  c.DateTime > DateTime.Now &&
                  !c.IsCanceled)
                .Include(c => c.Genre)
                .ToList();
        }

        public Concert GetConcertWithAttendees(int concertId)
        {
            return _context.Concerts
                .Include(c => c.Attendances.Select(a => a.Attendee))
                .SingleOrDefault(c => c.Id == concertId);
        }

        public IEnumerable<Concert> GetConcertsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Concert)
                .Include(c => c.Artist)
                .Include(c => c.Genre)
                .ToList();
        }

        public void Add(Concert concert)
        {
            _context.Concerts.Add(concert);
        }

        public IEnumerable<Concert> GetUpcomingConcerts(string searchTerm = null)
        {
            var upcomingConcerts = _context.Concerts
                .Include(c => c.Artist)
                .Include(c => c.Genre)
                .Where(c => c.DateTime > DateTime.Now && !c.IsCanceled);

            if (!String.IsNullOrWhiteSpace(searchTerm))
            {
                upcomingConcerts = upcomingConcerts
                    .Where(c =>
                             c.Artist.Name.Contains(searchTerm) ||
                             c.Genre.Name.Contains(searchTerm) ||
                             c.Venue.Contains(searchTerm));
            }

            return upcomingConcerts.ToList();
        }
    }
}