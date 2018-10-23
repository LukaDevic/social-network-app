using SocialNetworkApp.Models;
using System;

namespace SocialNetworkApp.Dtos
{
    public class NotificationDto
    {
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }

        public ConcertDto Concert { get; set; }
    }
}