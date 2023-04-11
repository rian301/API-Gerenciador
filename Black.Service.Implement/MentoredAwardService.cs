using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class MentoredAwardService : ServiceBaseCRUD<MentoredAward, int>, IMentoredAwardService
    {
        #region Properties
        private readonly IMentoredAwardRepository _repository;
        #endregion

        public MentoredAwardService(IMentoredAwardRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }

        public Task<List<MentoredAward>> GetAllAwardByMentored(int customerId) => _repository.GetAllAwardByMentored(customerId);

    }
}