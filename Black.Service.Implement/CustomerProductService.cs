using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class CustomerProductService : ServiceBaseCRUD<CustomerProduct, int>, ICustomerProductService
    {
        #region Properties
        private readonly ICustomerProductRepository _repository;
        #endregion

        public CustomerProductService(ICustomerProductRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }

        public Task<List<CustomerProduct>> GetAllProductByCustomer(int customerId) => _repository.GetAllProductByCustomer(customerId);
        public Task<List<CustomerProduct>> GetAllCustomerProductByIdCustomer(int customerId) => _repository.GetAllCustomerProductByIdCustomer(customerId);

    }
}
