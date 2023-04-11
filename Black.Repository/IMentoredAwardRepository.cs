using Black.Domain.Models;
using Black.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IMentoredAwardRepository : IRepositoryBaseCRUD<MentoredAward, int>
    {
        Task<List<MentoredAward>> GetAllAwardByMentored(int customerId);
    }
}
