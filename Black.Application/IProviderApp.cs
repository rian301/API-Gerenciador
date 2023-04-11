using Black.Application.Base;
using Black.Domain.Models;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IProviderApp : IAppBaseCRUD<Provider, int>
    {
        Task<int> QuantityProviders();
    }
}
