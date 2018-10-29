using SocialNetworkApp.Models;

namespace SocialNetworkApp.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string followerId, string followeId);
    }
}