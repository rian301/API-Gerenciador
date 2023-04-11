using Black.Domain.Models;
using Black.Repository.Base;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface ILaunchRepository : IRepositoryBaseCRUD<Launch, int>
    {
        public Task<int> QuantityLaunch();
    }
}
