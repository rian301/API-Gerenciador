using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Repository;
using Black.Service;
using Black.Service.Implement.Base;
using System.Collections.Generic;

namespace Procard.Service.Implement
{
    public class UserProfilePermissionService : ServiceBase, IUserProfilePermissionService
    {
        #region Properties
        private readonly IUserProfilePermissionRepository _repository;
        #endregion

        #region Constructors
        public UserProfilePermissionService(IUserProfilePermissionRepository repository, INotificationHandler<DomainNotification> notification) : base(repository, notification)
        {
            _repository = repository;
        }

        #endregion

        #region Methods
        public void Add(IList<UserProfilePermission> obj)
        {
            _repository.Add(obj);
        }

        public UserProfilePermission FindById(int idProfile)
        {
            return _repository.FindById(idProfile);
        }

        public IEnumerable<UserProfilePermission> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Permission> GetAllPermissions()
        {
            return _repository.GetAllPermissions();
        }

        public IEnumerable<GetAllPermissionsByIdUserProfileQueryResult> GetAllPermissionsByIdUserProfile(int userProfileId)
        {
            return _repository.GetAllPermissionsByIdUserProfile(userProfileId);
        }

        public IEnumerable<GetAllUserProfilePermissionWithPermissionNameQueryResult> GetAllUserProfilePermissionWithPermissionName()
        {
            return _repository.GetAllUserProfilePermissionWithPermissionName();
        }

        public IEnumerable<GetPermissionsByIdUserQueryResult> GetPermissionByIdUser(int userId)
        {
            return _repository.GetPermissionByIdUser(userId);
        }

        public void Update(IList<UserProfilePermission> obj)
        {
            _repository.Update(obj);
        }
        #endregion
    }
}
