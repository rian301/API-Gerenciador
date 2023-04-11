using Black.Application.Base;
using Black.Domain.Models;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IAwardApp : IAppBaseCRUD<Award, int>
    {
        Task<int> QuantityAwards();
    }
}
