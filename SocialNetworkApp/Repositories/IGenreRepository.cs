using System.Collections.Generic;
using SocialNetworkApp.Models;

namespace SocialNetworkApp.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}