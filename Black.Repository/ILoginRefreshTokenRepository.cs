using Black.Domain.Models;
using Black.Repository.Base;
using Procard.Domain.Models;

namespace Procard.Repository
{
    public interface ILoginRefreshTokenRepository : IRepositoryBaseCRUD<LoginRefreshToken, string>
    {
        LoginRefreshToken GetByUserToken(int idUser, string token);
    }
}
