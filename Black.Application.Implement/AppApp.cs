using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class AppApp : AppBaseCRUD<App, int>, IAppApp
    {
        #region Properties
        private readonly IAppService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public AppApp(IAppService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion

        public async Task<App> CreateOrUpdateAsync(App model)
        {
            var app = await GetByIdAsync(model.Id);

            if (model.DateCanceled != null)
                model.SetStatus(AppStatusEnum.Inactive);
            else
                model.SetStatus(AppStatusEnum.Active);

            if (app == null)
            {
                // Adiciona
                var appModel = new App(model.Name, model.DatePurchase, model.Requester, model.Value, model.Signature, model.Description, model.Responsible, model.DateCanceled, model.MotiveCancel, model.Status, model.Note);

                await base.AddAsync(appModel);

                return appModel;
            }

            app.Update(model.Name, model.DatePurchase, model.Requester, model.Value, model.Signature, model.Description, model.Responsible, model.DateCanceled, model.MotiveCancel, model.Status, model.Note);

            await _uow.SaveAsync();
            return app;
        }
    }
}
