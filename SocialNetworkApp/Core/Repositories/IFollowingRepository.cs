using SocialNetworkApp.Core.Models;

namespace SocialNetworkApp.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string followerId, string followeId);
        void Add(Following following);
        void Remove(Following following);
    }
}