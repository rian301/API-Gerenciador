using Black.Application.Base;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using System.Collections.Generic;

namespace Black.Application
{
    public interface IUserProfilePermissionApp : IAppBase
    {
        IEnumerable<UserProfilePermission> GetAll();
        UserProfilePermission FindById(int userProfileId);
        void Update(IList<UserProfilePermission> obj);
        void Add(IList<UserProfilePermission> obj);

        IEnumerable<GetAllUserProfilePermissionWithPermissionNameQueryResult> GetAllUserProfilePermissionWithPermissionName();
        IEnumerable<GetAllPermissionsByIdUserProfileQueryResult> GetAllPermissionsByIdUserProfile(int userProfileId);
        IEnumerable<GetPermissionsByIdUserQueryResult> GetPermissionByIdUser(int userId);
        IEnumerable<GetPermissionsByIdUserQueryResult> GetPermissionByUserLogged(int userId);
        IEnumerable<Permission> GetAllPermissions();

    }
}
