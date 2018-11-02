namespace SocialNetworkApp.Core.Models
{
    public class Attendance
    {
        public Concert Concert { get; set; }
        public ApplicationUser Attendee { get; set; }

        public int ConcertId { get; set; }

        public string AttendeeId { get; set; }
    }
}