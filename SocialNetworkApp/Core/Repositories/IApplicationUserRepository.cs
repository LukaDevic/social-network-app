using SocialNetworkApp.Core.Models;
using System.Collections.Generic;

namespace SocialNetworkApp.Core.Repositories

{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetArtistsFollowedBy(string userId);
    }
}