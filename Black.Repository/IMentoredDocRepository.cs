using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IMentoredDocRepository : IRepositoryBaseCRUD<MentoredDoc, Guid>
    {
        Task<MentoredDoc> GetByFileNameAsync(string filename);
        Task<List<MentoredDoc>> GetAllByMentoredIdAsync(int mentoredId);
        Task<List<MentoredDoc>> GetAllActives(int customerDependentId);
        Task<MentoredDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc);
        Task<MentoredDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc);
    }
}
