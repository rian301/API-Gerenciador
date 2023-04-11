using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IPendencyDocRepository : IRepositoryBaseCRUD<PendencyDoc, Guid>
    {
        Task<PendencyDoc> GetByFileNameAsync(string filename);
        Task<List<PendencyDoc>> GetAllByPendencyIdAsync(int mentoredId);
        Task<List<PendencyDoc>> GetAllActives(int customerDependentId);
        Task<PendencyDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc);
        Task<PendencyDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc);
    }
}
