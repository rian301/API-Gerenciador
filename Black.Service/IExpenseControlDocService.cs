using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IExpenseControlDocService : IServiceBaseCRUD<ExpenseControlDoc, Guid>
	{
		Task<List<ExpenseControlDoc>> GetAllByExpenseControlIdAsync(int expenseId);
		Task<List<ExpenseControlDoc>> GetAllActives(int expenseId);
		Task<ExpenseControlDoc> GetDocsActivesbyType(int expenseId, TypeDocEnum typedoc);
		Task<ExpenseControlDoc> ChangeStatusDoc(Guid docId, int expenseId, TypeDocEnum typedoc);
	}
}
