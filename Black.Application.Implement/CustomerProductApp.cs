using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class CustomerProductApp : AppBaseCRUD<CustomerProduct, int>, ICustomerProductApp
    {
        #region Properties
        private readonly ICustomerProductService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public CustomerProductApp(ICustomerProductService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion

        public Task<List<CustomerProduct>> GetAllProductByCustomer(int customerId) => _service.GetAllProductByCustomer(customerId);
        public Task<List<CustomerProduct>> GetAllCustomerProductByIdCustomer(int customerId) => _service.GetAllCustomerProductByIdCustomer(customerId);

    }
}
