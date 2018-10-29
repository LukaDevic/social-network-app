using SocialNetworkApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SocialNetworkApp.Repositories
{
    public class ConcertRepository
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

        public Concert GetSingleConcertFromAnArtist(int id, string userId)
        {
            return _context.Concerts.Single(c => c.Id == id && c.ArtistId == userId);
        }

        internal void Add(Concert concert)
        {
            _context.Concerts.Add(concert);
        }
    }
}