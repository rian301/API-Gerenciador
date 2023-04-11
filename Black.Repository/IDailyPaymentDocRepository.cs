using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IDailyPaymentDocRepository : IRepositoryBaseCRUD<DailyPaymentDoc, Guid>
    {
        Task<DailyPaymentDoc> GetByFileNameAsync(string filename);
        Task<List<DailyPaymentDoc>> GetAllByDailyPaymentIdAsync(int mentoredId);
        Task<List<DailyPaymentDoc>> GetAllActives(int customerDependentId);
        Task<DailyPaymentDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc);
        Task<DailyPaymentDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc);
    }
}
