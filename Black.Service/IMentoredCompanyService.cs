using Black.Domain.Models;
using Black.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IMentoredCompanyService : IServiceBaseCRUD<MentoredCompany, int>
    {
        Task<List<MentoredCompany>> GetAllCompanyByMentored(int mentoredId);
    }
}
