using System;
using System.ComponentModel.DataAnnotations;

namespace SocialNetworkApp.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Concert Concert { get; private set; }

        public Notification()
        {
        }

        private Notification(NotificationType type, Concert concert)
        {
            if (concert == null)
                throw new ArgumentNullException("concert");

            Type = type;
            Concert = concert;
            DateTime = DateTime.Now;
        }

        public static Notification ConcertCreated(Concert concert)
        {
            return new Notification(NotificationType.ConcertCreated, concert);
        }

        public static Notification ConcertUpdated(Concert newConcert, DateTime originalDateTime, string originalVenue)
        {
            var notification = new Notification(NotificationType.ConcertUpdated, newConcert);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;

            return notification;
        }

        public static Notification ConcertCanceled(Concert concert)
        {
            return new Notification(NotificationType.ConcertCanceled, concert);
        }

    }
}