using SocialNetworkApp.Models;
using System.Linq;

namespace SocialNetworkApp.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string followerId, string followeId)
        {
            return _context.Followings
                    .SingleOrDefault(f => f.FollowerId == followerId && f.FolloweeId == followeId);
        }
    }
}