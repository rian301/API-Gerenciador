using Black.Application.Base;
using Black.Domain.Models;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IPatrimonyApp : IAppBaseCRUD<Patrimony, int>
    {
        Task<int> QuantityPatrimonys();
    }
}
