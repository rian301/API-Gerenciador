using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class PartnerApp : AppBaseCRUD<Partner, int>, IPartnerApp
    {
        #region Properties
        private readonly IPartnerService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public PartnerApp(IPartnerService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion
        public Task<int> QuantityPartners() => _service.QuantityPartners();
        public Task<List<Partner>> GetByMentoredId(int mentoredId) => _service.GetByMentoredId(mentoredId);
        public Task<Partner> GetByMentoredPartnerId(int mentoredId) => _service.GetByMentoredPartnerId(mentoredId);
        public Task<Partner> GetByMentoredAndPartnerId(int id, int partnerId) => _service.GetByMentoredAndPartnerId(id, partnerId);
    }
}
