using Black.Domain.Models;
using Black.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IMentoredCompanyRepository : IRepositoryBaseCRUD<MentoredCompany, int>
    {
        Task<List<MentoredCompany>> GetAllCompanyByMentored(int mentoredId);
    }
}
