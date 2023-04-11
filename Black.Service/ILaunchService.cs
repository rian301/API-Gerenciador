using Black.Domain.Models;
using Black.Service.Base;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface ILaunchService : IServiceBaseCRUD<Launch, int>
    {
        Task<int> QuantityLaunch();
    }
}
