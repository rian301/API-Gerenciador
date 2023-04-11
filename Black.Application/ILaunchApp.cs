using Black.Application.Base;
using Black.Application.DTO;
using Black.Domain.Models;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface ILaunchApp : IAppBaseCRUD<Launch, int>
    {
        Task<Launch> UpdateAsync(LaunchDTO dto);
        Task<int?> QuantityLaunch();
    }
}
