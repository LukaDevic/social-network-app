using Microsoft.AspNet.Identity;
using SocialNetworkApp.Dtos;
using SocialNetworkApp.Models;
using System.Linq;
using System.Web.Http;

namespace SocialNetworkApp.Controllers.Api
{

    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();


            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.ConcertId == dto.ConcertId))
                return BadRequest("The attendance alrady exists.");


            var attendance = new Attendance
            {
                ConcertId = dto.ConcertId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _context.Attendances.SingleOrDefault(a => a.ConcertId == id && a.AttendeeId == userId);

            if (attendance == null)
                return NotFound();

            _context.Attendances.Remove(attendance);
            _context.SaveChanges();

            return Ok(id);
        }
    }

}
