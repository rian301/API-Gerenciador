using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using Procard.Domain.Models;
using Procard.Repository;

namespace Black.Service.Implement
{
    public class LoginRefreshTokenService : ServiceBaseCRUD<LoginRefreshToken, string>, ILoginRefreshTokenService
    {
        #region Properties
        private readonly ILoginRefreshTokenRepository _repository;
        #endregion

        #region Constructors
        public LoginRefreshTokenService(ILoginRefreshTokenRepository repository, INotificationHandler<DomainNotification> notification) : base(repository, notification)
        {
            _repository = repository;
        }
        #endregion

        public LoginRefreshToken GetByUserToken(int codigoUsuario, string token)
        {
            return _repository.GetByUserToken(codigoUsuario, token);
        }
    }
}
