using SocialNetworkApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkApp.Repositories
{
    public class GenreRepository
    {

        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

    }
}