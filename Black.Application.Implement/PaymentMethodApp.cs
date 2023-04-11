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
    public class PaymentMethodApp : AppBaseCRUD<PaymentMethod, int>, IPaymentMethodApp
    {
        #region Properties
        private readonly IPaymentMethodService _paymentMethodService;
        #endregion

        #region Constructors
        public PaymentMethodApp(IPaymentMethodService service, INotificationHandler<DomainNotification> notification, IUser user, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _paymentMethodService = service;
        }
        #endregion

        #region Methods
        public async Task<bool> CreateAsync(PaymentMethod model)
        {
            var method = await _paymentMethodService.GetByDescriptionAsync(model.Description);
            if (method != null)
            {
                _notification.Handle(new DomainNotification("DescriptionInvalid", "Já existe uma forma de pagamento com esta descrição."));
                return false;
            }
            model.SetStatus(PaymentTypeStatusEnum.Active);
            return await base.AddAsync(model);
        }

        public async Task<bool> StatusChangeAsync(int id, PaymentTypeStatusEnum status)
        {
            var payment = await _paymentMethodService.GetByIdAsync(id);
            payment.SetStatus(status);

            return await base.UpdateAsync(payment);
        }
        //public IEnumerable<PaymentMethod> GetAllActiveInCheckout() => _paymentMethodService.GetAllActiveInCheckout();
        //public IEnumerable<PaymentMethod> GetAllActiveInCheckoutOffline() => _paymentMethodService.GetAllActiveInCheckoutOffline();
        #endregion
    }
}
