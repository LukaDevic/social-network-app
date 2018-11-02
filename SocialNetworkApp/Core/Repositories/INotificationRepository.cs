using SocialNetworkApp.Core.Models;
using System.Collections.Generic;

namespace SocialNetworkApp.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetNewNotificationsFor(string userId);
    }
}