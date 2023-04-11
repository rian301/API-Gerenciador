using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class SentService : ServiceBaseCRUD<Sent, int>, ISentService
    {
        #region Properties
        private readonly ISentRepository _repository;
        #endregion

        public SentService(ISentRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }

        public Task<bool> GetByAwardAsync(int awardId, int customerId, int? ignoreId) => _repository.GetByAwardAsync(awardId, customerId, ignoreId);
        public Task<bool> GetMentoredByAwardAsync(int awardId, int mentoredId, int? ignoreId) => _repository.GetMentoredByAwardAsync(awardId, mentoredId, ignoreId);
        public Task<IQueryable<Sent>> GetAllPagination(QuerySentDTO filter, PaginationDTO pagination) => _repository.GetAllPagination(filter, pagination);
    }
}
