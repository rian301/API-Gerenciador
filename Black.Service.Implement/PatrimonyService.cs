using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class PatrimonyService : ServiceBaseCRUD<Patrimony, int>, IPatrimonyService
    {
        #region Properties
        private readonly IPatrimonyRepository _repository;
        #endregion

        public PatrimonyService(IPatrimonyRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
        public Task<int> QuantityPatrimonys() => _repository.QuantityPatrimonys();
    }
}
