using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class CustomerLaunchService : ServiceBaseCRUD<CustomerLaunch, int>, ICustomerLaunchService
    {
        #region Properties
        private readonly ICustomerLaunchRepository _repository;
        #endregion

        public CustomerLaunchService(ICustomerLaunchRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }

        public Task<List<CustomerLaunch>> GetAllLaunchByCustomer(int customerId) => _repository.GetAllLaunchByCustomer(customerId);

    }
}
