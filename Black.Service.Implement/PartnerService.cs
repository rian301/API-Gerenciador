using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class PartnerService : ServiceBaseCRUD<Partner, int>, IPartnerService
    {
        #region Properties
        private readonly IPartnerRepository _repository;
        #endregion

        public PartnerService(IPartnerRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
        public Task<int> QuantityPartners() => _repository.QuantityPartners();
        public Task<List<Partner>> GetByMentoredId(int mentoredId) => _repository.GetByMentoredId(mentoredId);
        public Task<Partner> GetByMentoredPartnerId(int mentoredId) => _repository.GetByMentoredPartnerId(mentoredId);
        public Task<Partner> GetByMentoredAndPartnerId(int id, int partnerId) => _repository.GetByMentoredAndPartnerId(id, partnerId);
    }
}
