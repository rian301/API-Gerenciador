using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class CustomerLaunchApp : AppBaseCRUD<CustomerLaunch, int>, ICustomerLaunchApp
    {
        #region Properties
        private readonly ICustomerLaunchService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public CustomerLaunchApp(ICustomerLaunchService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion

        public Task<List<CustomerLaunch>> GetAllLaunchByCustomer(int customerId) => _service.GetAllLaunchByCustomer(customerId);

    }
}
