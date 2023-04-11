using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class ProviderService : ServiceBaseCRUD<Provider, int>, IProviderService
    {
        #region Properties
        private readonly IProviderRepository _repository;
        #endregion

        public ProviderService(IProviderRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
        public Task<int> QuantityProviders() => _repository.QuantityProviders();
    }
}
