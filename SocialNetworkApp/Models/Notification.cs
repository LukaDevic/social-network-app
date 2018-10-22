using System;
using System.ComponentModel.DataAnnotations;

namespace SocialNetworkApp.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }

        [Required]
        public Concert Concert { get; set; }
    }
}