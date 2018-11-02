using SocialNetworkApp.Core.Models;
using SocialNetworkApp.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SocialNetworkApp.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetNewNotificationsFor(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Concert.Artist)
                .ToList();
        }
    }
}