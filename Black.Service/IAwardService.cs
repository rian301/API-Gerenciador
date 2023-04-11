using Black.Domain.Models;
using Black.Service.Base;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IAwardService : IServiceBaseCRUD<Award, int>
    {
        Task<int> QuantityAwards();
    }
}
