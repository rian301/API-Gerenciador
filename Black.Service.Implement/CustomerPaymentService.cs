using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class CustomerPaymentService : ServiceBaseCRUD<CustomerPayment, int>, ICustomerPaymentService
    {
        #region Properties
        private readonly ICustomerPaymentRepository _repository;
        #endregion

        public CustomerPaymentService(ICustomerPaymentRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }

        public Task<List<CustomerPayment>> GetAllPaymentByCustomer(int customerId) => _repository.GetAllPaymentByCustomer(customerId);

    }
}
