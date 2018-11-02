using Microsoft.AspNet.Identity;
using SocialNetworkApp.Core;
using System.Web.Http;

namespace SocialNetworkApp.Controllers.Api
{
    [Authorize]
    public class ConcertsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConcertsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var concert = _unitOfWork.Concerts.GetConcertWithAttendees(id);

            //TODO: Bug - if concert == null
            if (concert.IsCanceled)
                return NotFound();

            if (concert.ArtistId != userId)
                return Unauthorized();

            concert.Cancel();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
