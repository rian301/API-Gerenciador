using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class PaymentMethodService : ServiceBaseCRUD<PaymentMethod, int>, IPaymentMethodService
    {
        #region Properties
        private readonly IPaymentMethodRepository _repository;
        #endregion

        #region Constructors
        public PaymentMethodService(IPaymentMethodRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        //public IEnumerable<PaymentMethod> GetAllActiveInCheckout()
        //{
        //    return _repository.TableNoTracking().Where(w => w.Active && w.ActiveInCheckout).ToList();
        //}

        //public IEnumerable<PaymentMethod> GetAllActiveInCheckoutOffline()
        //{
        //    return _repository.TableNoTracking().Where(w => w.Active && w.ActiveInCheckoutOffline).ToList();
        //}
        public Task<PaymentMethod> GetByDescriptionAsync(string description) => _repository.GetByDescriptionAsync(description);

        #endregion
    }
}
