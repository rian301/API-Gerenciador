using Black.Domain.Models;
using Black.Service.Base;
using Procard.Domain.Models;

namespace Black.Service
{
    public interface ILoginRefreshTokenService : IServiceBaseCRUD<LoginRefreshToken, string>
    {
        LoginRefreshToken GetByUserToken(int idUser, string token);
    }
}
