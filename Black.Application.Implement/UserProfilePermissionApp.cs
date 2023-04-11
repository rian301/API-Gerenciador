using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Service;
using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using System.Collections.Generic;

namespace Black.Application.Implement
{
    public class UserProfilePermissionApp : AppBase, IUserProfilePermissionApp
    {
        #region Properties
        private readonly IUserProfilePermissionService _service;
        #endregion

        #region Constructors

        public UserProfilePermissionApp(IUserProfilePermissionService service, INotificationHandler<DomainNotification> notification, IUser user) : base(service, notification, user)
        {
            _service = service;
        }

        #endregion

        #region Methods
        public void Add(IList<UserProfilePermission> obj)
        {
            _service.Add(obj);
        }

        public UserProfilePermission FindById(int idProfile)
        {
            return _service.FindById(idProfile);
        }

        public IEnumerable<UserProfilePermission> GetAll()
        {
            return _service.GetAll();
        }

        public IEnumerable<Permission> GetAllPermissions()
        {
            return _service.GetAllPermissions();
        }

        public IEnumerable<GetAllPermissionsByIdUserProfileQueryResult> GetAllPermissionsByIdUserProfile(int userProfileId)
        {
            return _service.GetAllPermissionsByIdUserProfile(userProfileId);
        }

        public IEnumerable<GetAllUserProfilePermissionWithPermissionNameQueryResult> GetAllUserProfilePermissionWithPermissionName()
        {
            return _service.GetAllUserProfilePermissionWithPermissionName();
        }

        public IEnumerable<GetPermissionsByIdUserQueryResult> GetPermissionByIdUser(int idUser)
        {
            return _service.GetPermissionByIdUser(idUser);
        }

        public IEnumerable<GetPermissionsByIdUserQueryResult> GetPermissionByUserLogged(int idUser)
        {
            return GetPermissionByIdUser(idUser);
        }

        public void Update(IList<UserProfilePermission> obj)
        {
            foreach (var item in obj)
            {
                var ret = FindById(item.UserProfileId);
                ret.Update(item.UserProfileId, item.PermissionId, _user.Id.Value);
            }
            _service.Update(obj);
        }
        #endregion
    }
}
