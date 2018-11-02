using SocialNetworkApp.Core.Models;
using System.Collections.Generic;

namespace SocialNetworkApp.Core.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}