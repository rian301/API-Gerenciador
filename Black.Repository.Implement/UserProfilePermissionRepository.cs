using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Domain.Core.Notifications;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using System.Collections.Generic;
using System.Linq;

namespace Black.Repository.Implement
{
    public class UserProfilePermissionRepository : RepositoryBase, IUserProfilePermissionRepository
    {
        public UserProfilePermissionRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public void Add(IList<UserProfilePermission> obj)
        {
            Context.UserProfilePermission.AddRange(obj);
        }

        public UserProfilePermission FindById(int userProfileId)
        {
            return Context.UserProfilePermission.Where(x => x.UserProfileId == userProfileId).FirstOrDefault();
        }

        public IEnumerable<UserProfilePermission> GetAll()
        {
            return Context.UserProfilePermission.ToList();
        }

        public IEnumerable<Permission> GetAllPermissions()
        {
            return Context.Permission.ToList();
        }

        public IEnumerable<GetAllPermissionsByIdUserProfileQueryResult> GetAllPermissionsByIdUserProfile(int userProfileId)
        {
            return (from a in Context.Permission
                    join b in Context.UserProfilePermission on new { op1 = a.Id, op2 = userProfileId } equals new { op1 = b.PermissionId, op2 = b.UserProfileId } into _b
                    from b in _b.DefaultIfEmpty()
                    select new GetAllPermissionsByIdUserProfileQueryResult
                    {
                        PermissionId = a.Id,
                        ConstName = a.ConstPermission,
                        PermissionName = a.Name,
                        Checked = (b != null ? true : false)
                    }).OrderBy(x => x.ConstName).ToList();
        }

        public IEnumerable<GetAllUserProfilePermissionWithPermissionNameQueryResult> GetAllUserProfilePermissionWithPermissionName()
        {
            return (from a in Context.UserProfilePermission
                    join b in Context.Permission on a.PermissionId equals b.Id
                    select new GetAllUserProfilePermissionWithPermissionNameQueryResult
                    {
                        permissionId = a.PermissionId,
                        userProfileId = a.UserProfileId,
                        PermissionName = b.Name
                    }).ToList();
        }

        public IEnumerable<GetPermissionsByIdUserQueryResult> GetPermissionByIdUser(int userId)
        {
            var ret = (from a in Context.User
                       join b in Context.UserProfilePermission on a.UserProfileId equals b.UserProfileId
                       join c in Context.Permission on b.PermissionId equals c.Id
                       where a.Id == userId
                       select new GetPermissionsByIdUserQueryResult
                       {
                           Name = c.Name,
                           ConstPermission = c.ConstPermission,
                           Checked = (b.PermissionId.ToString() != null ? true : false)
                       }).OrderBy(x => x.ConstPermission).ToList();
            return ret;
        }

        public void Update(IList<UserProfilePermission> obj)
        {
            Context.UserProfilePermission.UpdateRange(obj);
        }
    }
}
