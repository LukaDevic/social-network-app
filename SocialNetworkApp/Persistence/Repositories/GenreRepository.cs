using SocialNetworkApp.Core.Models;
using SocialNetworkApp.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkApp.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
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