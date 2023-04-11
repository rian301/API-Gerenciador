using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class AssetsCategoryService : ServiceBaseCRUD<AssetsCategory, int>, IAssetsCategoryService
    {
        #region Properties
        private readonly IAssetsCategoryRepository _repository;
        #endregion

        public AssetsCategoryService(IAssetsCategoryRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
        public Task<int> QuantityAssetsCategorys() => _repository.QuantityAssetsCategorys();
    }
}
