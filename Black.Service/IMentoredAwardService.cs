using Black.Domain.Models;
using Black.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IMentoredAwardService : IServiceBaseCRUD<MentoredAward, int>
    {
        Task<List<MentoredAward>> GetAllAwardByMentored(int customerId);
    }
}
