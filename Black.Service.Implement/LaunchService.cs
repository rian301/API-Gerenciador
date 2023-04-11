using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class LaunchService : ServiceBaseCRUD<Launch, int>, ILaunchService
    {
        #region Properties

        private readonly ILaunchRepository _launchRepository;

        #endregion

        public LaunchService(ILaunchRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _launchRepository = repository;
        }
        public Task<int> QuantityLaunch() => _launchRepository.QuantityLaunch();

    }
}
