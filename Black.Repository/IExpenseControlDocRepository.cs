using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IExpenseControlDocRepository : IRepositoryBaseCRUD<ExpenseControlDoc, Guid>
    {
        Task<ExpenseControlDoc> GetByFileNameAsync(string filename);
        Task<List<ExpenseControlDoc>> GetAllByExpenseControlIdAsync(int expenseId);
        Task<List<ExpenseControlDoc>> GetAllActives(int expensetId);
        Task<ExpenseControlDoc> GetDocsActivesbyType(int expensetId, TypeDocEnum typedoc);
        Task<ExpenseControlDoc> ChangeStatusDoc(Guid docId, int expenseId, TypeDocEnum typedoc);
    }
}
