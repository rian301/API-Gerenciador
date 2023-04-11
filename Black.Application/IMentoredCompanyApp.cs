using Black.Application.Base;
using Black.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IMentoredCompanyApp : IAppBaseCRUD<MentoredCompany, int>
    {
        Task<List<MentoredCompany>> GetAllCompanyByMentored(int mentoredId);
    }
}
