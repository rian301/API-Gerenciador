using Black.Application.Base;
using Black.Domain.Enums;
using Black.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IPaymentMethodApp : IAppBaseCRUD<PaymentMethod, int>
    {
        //IEnumerable<PaymentMethod> GetAllActiveInCheckout();
        //IEnumerable<PaymentMethod> GetAllActiveInCheckoutOffline();
        Task<bool> CreateAsync(PaymentMethod model);
        Task<bool> StatusChangeAsync(int id, PaymentTypeStatusEnum status);
    }
}
