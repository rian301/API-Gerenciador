using Black.Application.DTO;
using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class UserProfileApp : AppBaseCRUD<UserProfile, int>, IUserProfileApp
    {
        private readonly IUserProfileService _service;
        private readonly IUserProfilePermissionService _userProfilePermissionService;
        public UserProfileApp(IUserProfileService service, IUserProfilePermissionService userProfilePermissionService, INotificationHandler<DomainNotification> notification, IUser user, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _userProfilePermissionService = userProfilePermissionService;
            _service = service;
        }

        public override async Task<bool> UpdateAsync(UserProfile obj)
        {
            var perfilDb = await _service.GetByIdAsync(obj.Id);
            perfilDb.Update(obj.Name);

            _service.Update(obj);
            return await _uow.SaveAsync();
        }

        public override async Task<UserProfile> GetByIdAsync(int Id)
        {
            if (Id == 0)
                return null;

            return await _service.GetByIdAsync(Id);
        }

        public void AddUserProfilePermission(IList<UserProfilePermission> userProfilePermission, int idUserChange)
        {
            _userProfilePermissionService.Add(userProfilePermission);
            _uow.Save();
        }

        public async Task<UserProfile> UpdateAsync(DTOChangeUserProfile dtoUserProfile)
        {
            var userProfileDb = await GetByIdAsync(dtoUserProfile.Id);

            userProfileDb.Update(dtoUserProfile.Name);
            userProfileDb.UpdateUserProfilePermissions(dtoUserProfile.Permissions, _user.Id.Value);

            _service.Update(userProfileDb);

            if (_notification.HasNotifications())
                return null;

            if (!_uow.Save())
                return null;

            return userProfileDb;
        }
    }
}
