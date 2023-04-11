using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class MentoredAwardApp : AppBaseCRUD<MentoredAward, int>, IMentoredAwardApp
    {
        #region Properties
        private readonly IMentoredAwardService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public MentoredAwardApp(IMentoredAwardService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion

        public Task<List<MentoredAward>> GetAllAwardByMentored(int customerId) => _service.GetAllAwardByMentored(customerId);

    }
}
