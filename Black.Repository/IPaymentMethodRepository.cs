using Black.Domain.Models;
using Black.Repository.Base;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IPaymentMethodRepository : IRepositoryBaseCRUD<PaymentMethod, int>
    {
        Task<PaymentMethod> GetByDescriptionAsync(string description);
    }
}
