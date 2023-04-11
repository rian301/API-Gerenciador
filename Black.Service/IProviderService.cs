using Black.Domain.Models;
using Black.Service.Base;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IProviderService : IServiceBaseCRUD<Provider, int>
    {
        Task<int> QuantityProviders();
    }
}
