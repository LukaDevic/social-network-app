using SocialNetworkApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkApp.ViewModels
{
    public class ConcertsViewModel
    {
        public IEnumerable<Concert> UpcomingConcerts { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Attendance> Attendances { get; set; }
    }
}