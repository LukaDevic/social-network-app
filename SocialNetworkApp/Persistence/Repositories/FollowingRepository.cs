using SocialNetworkApp.Core.Models;
using SocialNetworkApp.Core.Repositories;
using SocialNetworkApp.Persistence;
using System.Linq;

namespace SocialNetworkApp.Persitence.Repositories
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

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }

    }
}