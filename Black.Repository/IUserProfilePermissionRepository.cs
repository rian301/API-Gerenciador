using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Repository.Base;
using System.Collections.Generic;

namespace Black.Repository
{
    public interface IUserProfilePermissionRepository : IRepositoryBase
    {
        IEnumerable<UserProfilePermission> GetAll();
        UserProfilePermission FindById(int idProfile);
        void Update(IList<UserProfilePermission> obj);
        void Add(IList<UserProfilePermission> obj);
        IEnumerable<GetAllUserProfilePermissionWithPermissionNameQueryResult> GetAllUserProfilePermissionWithPermissionName();
        IEnumerable<GetAllPermissionsByIdUserProfileQueryResult> GetAllPermissionsByIdUserProfile(int userProfileId);
        IEnumerable<GetPermissionsByIdUserQueryResult> GetPermissionByIdUser(int userId);

        IEnumerable<Permission> GetAllPermissions();
    }
}
