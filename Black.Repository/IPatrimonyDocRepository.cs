using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IPatrimonyDocRepository : IRepositoryBaseCRUD<PatrimonyDoc, Guid>
    {
        Task<PatrimonyDoc> GetByFileNameAsync(string filename);
        Task<List<PatrimonyDoc>> GetAllByPatrimonyIdAsync(int mentoredId);
        Task<List<PatrimonyDoc>> GetAllActives(int customerDependentId);
        Task<PatrimonyDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc);
        Task<PatrimonyDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc);
    }
}
