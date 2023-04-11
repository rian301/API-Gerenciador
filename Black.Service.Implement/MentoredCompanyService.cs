using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class MentoredCompanyService : ServiceBaseCRUD<MentoredCompany, int>, IMentoredCompanyService
    {
        #region Properties
        private readonly IMentoredCompanyRepository _repository;
        #endregion

        public MentoredCompanyService(IMentoredCompanyRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }

        public Task<List<MentoredCompany>> GetAllCompanyByMentored(int mentoredId) => _repository.GetAllCompanyByMentored(mentoredId);
    }
}
