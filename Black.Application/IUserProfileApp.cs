using Black.Application.Base;
using Black.Application.DTO;
using Black.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IUserProfileApp : IAppBaseCRUD<UserProfile, int>
    {
        #region UserProfile Methods
        Task<UserProfile> UpdateAsync(DTOChangeUserProfile dtoPerfilUsuario);
        void AddUserProfilePermission(IList<UserProfilePermission> userProfilePermission, int idUserChange);
        #endregion
    }
}
