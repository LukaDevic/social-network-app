using SocialNetworkApp.Core.Models;
using System.Collections.Generic;

namespace SocialNetworkApp.Core.Repositories
{
    public interface IUserNotificationRepository
    {
        IEnumerable<UserNotification> GetUserNotificationsFor(string userId);
    }
}