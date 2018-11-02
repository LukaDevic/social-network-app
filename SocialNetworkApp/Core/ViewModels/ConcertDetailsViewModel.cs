using SocialNetworkApp.Core.Models;

namespace SocialNetworkApp.Core.ViewModels
{
    public class ConcertDetailsViewModel
    {
        public Concert Concert { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }
    }
}