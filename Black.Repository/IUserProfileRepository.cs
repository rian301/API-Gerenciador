using Black.Domain.Models;
using Black.Repository.Base;

namespace Black.Repository
{
    public interface IUserProfileRepository : IRepositoryBaseCRUD<UserProfile, int>
    {
    }
}
