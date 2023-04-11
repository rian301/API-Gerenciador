using Black.Domain.Models;
using Black.Repository.Base;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IPendencyRepository : IRepositoryBaseCRUD<Pendency, int>
    {
        Task<Pendency> GetByDescriptionAsync(string description);
    }
}
