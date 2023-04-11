using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class AwardService : ServiceBaseCRUD<Award, int>, IAwardService
    {
        #region Properties
        private readonly IAwardRepository _repository;
        #endregion

        public AwardService(IAwardRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
        public Task<int> QuantityAwards() => _repository.QuantityAwards();
    }
}
