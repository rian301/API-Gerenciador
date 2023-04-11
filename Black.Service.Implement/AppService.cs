using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class AppService : ServiceBaseCRUD<App, int>, IAppService
    {
        #region Properties
        private readonly IAppRepository _repository;
        #endregion

        public AppService(IAppRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
    }
}
