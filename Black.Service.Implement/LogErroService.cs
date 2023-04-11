using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;

namespace Black.Service.Implement
{
    public class LogErroService : ILogErroService
    {
        #region Properties
        private readonly ILogErroRepository _repositorio;
        #endregion

        #region Constructors
        public LogErroService(ILogErroRepository repositorio, INotificationHandler<DomainNotification> notification)
        {
            _repositorio = repositorio;
        }
        #endregion

        #region Methods
        public void Insert(LogErro obj)
        {
            _repositorio.Insert(obj);
        }
        #endregion

    }
}
