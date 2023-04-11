using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class PendencyApp : AppBaseCRUD<Pendency, int>, IPendencyApp
    {
        #region Properties
        private readonly IPendencyService _pendencyService;
        #endregion

        #region Constructors
        public PendencyApp(IPendencyService service, INotificationHandler<DomainNotification> notification, IUser user, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _pendencyService = service;
        }
        #endregion

        #region Methods
        //public async Task<Pendency> CreateAsync(Pendency model)
        //{
        //    if (model.ResolveDate != null)
        //        model.SetStatus(PendencyStatusEnum.Resolved);
        //    else
        //        model.SetStatus(PendencyStatusEnum.InProgress);

        //    // Adiciona
        //    var pendency = new Pendency(model.Name, model.IncludDate, model.Requester, model.Description, model.Responsible, model.ResolveDate, model.Status);

        //    await base.AddAsync(pendency);
        //    return pendency;
        //}

        public async Task<Pendency> CreateOrUpdateAsync(Pendency model)
        {
            var pendency = await GetByIdAsync(model.Id);

            if (model.ResolveDate != null)
                model.SetStatus(PendencyStatusEnum.Resolved);
            else
                model.SetStatus(PendencyStatusEnum.InProgress);

            if (pendency == null)
            {
                // Adiciona
                var pendencyModel = new Pendency(model.Name, model.IncludDate, model.Requester, model.Description, model.Responsible, model.ResolveDate, model.Status);

                await base.AddAsync(pendencyModel);

                return pendencyModel;
            }

            pendency.Update(model.Name, model.IncludDate, model.Requester, model.Description, model.Responsible, model.ResolveDate, model.Status);

            await _uow.SaveAsync();
            return pendency;
        }

        public async Task<bool> StatusChangeAsync(int id, PendencyStatusEnum status)
        {
            var payment = await _pendencyService.GetByIdAsync(id);
            payment.SetStatus(status);

            return await base.UpdateAsync(payment);
        }
        //public IEnumerable<Pendency> GetAllActiveInCheckout() => _pendencyService.GetAllActiveInCheckout();
        //public IEnumerable<Pendency> GetAllActiveInCheckoutOffline() => _pendencyService.GetAllActiveInCheckoutOffline();
        #endregion
    }
}
