using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class MentoredCompanyApp : AppBaseCRUD<MentoredCompany, int>, IMentoredCompanyApp
    {
        #region Properties
        private readonly IMentoredCompanyService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public MentoredCompanyApp(IMentoredCompanyService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }

        public Task<List<MentoredCompany>> GetAllCompanyByMentored(int mentoredId) => _service.GetAllCompanyByMentored(mentoredId);
        #endregion
    }
}
