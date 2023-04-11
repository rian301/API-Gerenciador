using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IGiftDocRepository : IRepositoryBaseCRUD<GiftDoc, Guid>
    {
        Task<GiftDoc> GetByFileNameAsync(string filename);
        Task<List<GiftDoc>> GetAllByGiftIdAsync(int expenseId);
        Task<List<GiftDoc>> GetAllActives(int expensetId);
        Task<GiftDoc> GetDocsActivesbyType(int expensetId, TypeDocEnum typedoc);
        Task<GiftDoc> ChangeStatusDoc(Guid docId, int expenseId, TypeDocEnum typedoc);
    }
}
