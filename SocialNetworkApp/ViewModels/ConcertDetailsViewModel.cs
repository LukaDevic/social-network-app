using SocialNetworkApp.Models;

namespace SocialNetworkApp.ViewModels
{
    public class ConcertDetailsViewModel
    {
        public Concert Concert { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }
    }
}