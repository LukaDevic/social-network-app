using Microsoft.AspNet.Identity;
using SocialNetworkApp.Models;
using System;
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
            var notification = new Notification
            {
                DateTime = DateTime.Now,
                Concert = concert,
                Type = NotificationType.ConcerCanceled
            };

            var attendees = _context.Attendances
                .Where(a => a.ConcertId == concert.Id)
                .Select(a => a.Attendee)
                .ToList();

            foreach (var attendee in attendees)
            {
                var userNotification = new UserNotification
                {
                    User = attendee,
                    Notification = notification
                };
                _context.UserNotifications.Add(userNotification);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
