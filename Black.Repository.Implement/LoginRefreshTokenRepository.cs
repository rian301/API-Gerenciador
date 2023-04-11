using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Procard.Domain.Models;
using Procard.Repository;
using System;
using System.Linq;

namespace Black.Repository.Implement
{
    public class LoginRefreshTokenRepository : RepositoryBaseCRUD<LoginRefreshToken, string>, ILoginRefreshTokenRepository
    {
        #region Construtor
        public LoginRefreshTokenRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }
        #endregion

        public LoginRefreshToken GetByUserToken(int idUser, string token)
        {
            var obj = Context.LoginRefreshToken.Where(w => w.IdUser == idUser && w.Id == token && w.DueDate > DateTime.Now)
                           .FirstOrDefault();
            return obj;
        }

    }
}
