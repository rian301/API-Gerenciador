using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class CustomerAwardService : ServiceBaseCRUD<CustomerAward, int>, ICustomerAwardService
    {
        #region Properties
        private readonly ICustomerAwardRepository _repository;
        #endregion

        public CustomerAwardService(ICustomerAwardRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }

        public Task<List<CustomerAward>> GetAllAwardByCustomer(int customerId) => _repository.GetAllAwardByCustomer(customerId);

    }
}