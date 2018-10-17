using Microsoft.AspNet.Identity;
using SocialNetworkApp.Dtos;
using SocialNetworkApp.Models;
using System.Linq;
using System.Web.Http;

namespace SocialNetworkApp.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var followerId = User.Identity.GetUserId();

            if (_context.Followings.Any(f => f.FollowerId == followerId && f.FolloweeId == dto.FolloweeId))
                return BadRequest("You allready follow this artist");


            var following = new Following
            {
                FollowerId = followerId,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
