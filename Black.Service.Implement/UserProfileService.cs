using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service;
using Black.Service.Implement.Base;

namespace Procard.Service.Implement
{
    public class UserProfileService : ServiceBaseCRUD<UserProfile, int>, IUserProfileService
    {
        public UserProfileService(IUserProfileRepository repository, INotificationHandler<DomainNotification> notification) : base(repository, notification)
        {
        }
    }
}
