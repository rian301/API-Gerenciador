using Black.Application.Base;
using Black.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IMentoredAwardApp : IAppBaseCRUD<MentoredAward, int>
    {
        Task<List<MentoredAward>> GetAllAwardByMentored(int mentoredId);
    }
}
