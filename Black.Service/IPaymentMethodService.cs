using Black.Domain.Models;
using Black.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IPaymentMethodService : IServiceBaseCRUD<PaymentMethod, int>
    {
        //IEnumerable<PaymentMethod> GetAllActiveInCheckout();
        //IEnumerable<PaymentMethod> GetAllActiveInCheckoutOffline();
        Task<PaymentMethod> GetByDescriptionAsync(string description);
    }
}
