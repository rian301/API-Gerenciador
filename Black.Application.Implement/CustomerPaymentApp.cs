using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class CustomerPaymentApp : AppBaseCRUD<CustomerPayment, int>, ICustomerPaymentApp
    {
        #region Properties
        private readonly ICustomerPaymentService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public CustomerPaymentApp(ICustomerPaymentService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion

        public Task<List<CustomerPayment>> GetAllPaymentByCustomer(int customerId) => _service.GetAllPaymentByCustomer(customerId);

    }
}
