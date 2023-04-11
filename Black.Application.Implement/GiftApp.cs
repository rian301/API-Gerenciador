using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class GiftApp : AppBaseCRUD<Gift, int>, IGiftApp
    {
        #region Properties
        private readonly IGiftService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public GiftApp(IGiftService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion

        public async Task<Gift> CreateOrUpdateAsync(Gift model)
        {
            var app = await GetByIdAsync(model.Id);

            if (app == null)
            {
                // Adiciona
                var appModel = new Gift(model.Name, model.DateIncluse, model.Responsible, model.Quantity, model.Entrance, model.Exit);

                await base.AddAsync(appModel);

                return appModel;
            }

            app.Update(model.Name, model.DateIncluse, model.Responsible, model.Quantity, model.Entrance, model.Exit);

            await _uow.SaveAsync();
            return app;
        }
    }
}
