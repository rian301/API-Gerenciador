using Black.Application.DTO;
using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class LaunchApp : AppBaseCRUD<Launch, int>, ILaunchApp
    {
        #region Properties
        private readonly ILaunchService _launchService;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public LaunchApp(ILaunchService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _launchService = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion

        #region Methods
        public async Task<Launch> UpdateAsync(LaunchDTO dto)
        {
            var lauch = await GetByIdAsync(dto.Id);

            if (lauch == null)
            {
                _notification.Handle(new DomainNotification("LaunchNotFound", "Lançamento não encontrado."));
                return null;
            }

            lauch.Update(dto.Description, dto.Date, dto.QuantityStudents, dto.Invoice, dto.Investment, dto.TopCriative, dto.Note);

            lauch.SetUserChangeId(_user.Id.Value);

            await base.UpdateAsync(lauch);

            return lauch;
        }

        public async Task<int?> QuantityLaunch()
        {
            return await _launchService.QuantityLaunch();
        }
        #endregion
    }
}
