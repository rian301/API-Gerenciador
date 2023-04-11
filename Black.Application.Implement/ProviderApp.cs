using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class ProviderApp : AppBaseCRUD<Provider, int>, IProviderApp
    {
        #region Properties
        private readonly IProviderService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public ProviderApp(IProviderService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion
        public Task<int> QuantityProviders() => _service.QuantityProviders();
    }
}
