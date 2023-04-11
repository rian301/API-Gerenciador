using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class GiftService : ServiceBaseCRUD<Gift, int>, IGiftService
    {
        #region Properties
        private readonly IGiftRepository _repository;
        #endregion

        public GiftService(IGiftRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
    }
}
