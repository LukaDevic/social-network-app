using SocialNetworkApp.Core.Models;
using System.Collections.Generic;

namespace SocialNetworkApp.Core.Repositories
{
    public interface IConcertRepository
    {
        Concert GetConcert(int concertId);
        IEnumerable<Concert> GetConcertsUserAttending(string userId);
        Concert GetConcertWithAttendees(int concertId);
        IEnumerable<Concert> GetUpcomingConcertsByArtist(string artistId);
        void Add(Concert concert);

        IEnumerable<Concert> GetUpcomingConcerts(string searchTerm = null);
    }
}