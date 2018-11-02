using Microsoft.AspNet.Identity;
using SocialNetworkApp.Core;
using SocialNetworkApp.Core.Dtos;
using SocialNetworkApp.Core.Models;
using System.Web.Http;

namespace SocialNetworkApp.Controllers.Api
{

    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _unitOfWork.Attendances.GetAttendance(dto.ConcertId, userId);
            if (attendance != null)
                return BadRequest("The attendance alrady exists.");


            attendance = new Attendance
            {
                ConcertId = dto.ConcertId,
                AttendeeId = userId
            };
            _unitOfWork.Attendances.Add(attendance);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _unitOfWork.Attendances.GetAttendance(id, userId);

            if (attendance == null)
                return NotFound();

            _unitOfWork.Attendances.Remove(attendance);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }

}
