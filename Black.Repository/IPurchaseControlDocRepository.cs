using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IPurchaseControlDocRepository : IRepositoryBaseCRUD<PurchaseControlDoc, Guid>
    {
        Task<PurchaseControlDoc> GetByFileNameAsync(string filename);
        Task<List<PurchaseControlDoc>> GetAllByPurchaseControlIdAsync(int mentoredId);
        Task<List<PurchaseControlDoc>> GetAllActives(int customerDependentId);
        Task<PurchaseControlDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc);
        Task<PurchaseControlDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc);
    }
}
