using Black.Domain.Models;
using Black.Service.Base;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IPatrimonyService : IServiceBaseCRUD<Patrimony, int>
    {
        Task<int> QuantityPatrimonys();
    }
}
