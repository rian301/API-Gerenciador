using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class ExpenseControlDocRepository : RepositoryBaseCRUD<ExpenseControlDoc, Guid>, IExpenseControlDocRepository
	{
		public ExpenseControlDocRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
		{
		}

		public Task<ExpenseControlDoc> GetByFileNameAsync(string filename)
		{
			return dbSet.Where(w => w.FileName.Equals(filename)).FirstOrDefaultAsync();
		}

		public Task<List<ExpenseControlDoc>> GetAllByExpenseControlIdAsync(int expenseId)
		{
			return dbSet.AsNoTracking()
						.Where(w => w.ExpenseControlId == expenseId)
						.OrderByDescending(o => o.CreatedAt)
						.ToListAsync();
		}

		public Task<List<ExpenseControlDoc>> GetAllActives(int expenseId)
        {
			return dbSet.AsNoTracking().Where(w => w.ExpenseControlId == expenseId && w.Active).ToListAsync();
		}

		public Task<ExpenseControlDoc> GetDocsActivesbyType(int expenseId, TypeDocEnum typedoc)
		{
			return dbSet.AsNoTracking().Where(w => w.ExpenseControlId == expenseId && w.Active).FirstOrDefaultAsync();
		}

		public Task<ExpenseControlDoc> ChangeStatusDoc(Guid docId, int expenseId, TypeDocEnum typedoc)
		{
			return dbSet.AsNoTracking().Where(w => w.Id == docId && w.ExpenseControlId == expenseId).FirstOrDefaultAsync();
		}
	}
}
