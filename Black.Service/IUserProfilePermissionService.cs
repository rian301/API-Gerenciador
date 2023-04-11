using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Service.Base;
using System.Collections.Generic;

namespace Black.Service
{
    public interface IUserProfilePermissionService : IServiceBase
    {
        IEnumerable<UserProfilePermission> GetAll();
        UserProfilePermission FindById(int idProfile);
        void Update(IList<UserProfilePermission> obj);
        void Add(IList<UserProfilePermission> obj);
        IEnumerable<GetAllUserProfilePermissionWithPermissionNameQueryResult> GetAllUserProfilePermissionWithPermissionName();
        IEnumerable<GetAllPermissionsByIdUserProfileQueryResult> GetAllPermissionsByIdUserProfile(int userProfileId);
        IEnumerable<GetPermissionsByIdUserQueryResult> GetPermissionByIdUser(int idUser);

        IEnumerable<Permission> GetAllPermissions();

    }
}
