using Microsoft.AspNet.Identity;
using SocialNetworkApp.Models;
using System.Linq;
using System.Web.Http;

namespace SocialNetworkApp.Controllers.Api
{
    [Authorize]
    public class ConcertsController : ApiController
    {
        private ApplicationDbContext _context;

        public ConcertsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var concert = _context.Concerts.Single(c => c.Id == id && c.ArtistId == userId);

            if (concert.IsCanceled)
                return NotFound();

            concert.IsCanceled = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
