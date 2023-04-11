using Black.Application.Base;
using Black.Domain.Models;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IAppApp : IAppBaseCRUD<App, int>
    {
        Task<App> CreateOrUpdateAsync(App model);
    }
}
