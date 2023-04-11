using Black.Application.Base;
using Black.Domain.Models;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IGiftApp : IAppBaseCRUD<Gift, int>
    {
        Task<Gift> CreateOrUpdateAsync(Gift model);
    }
}
