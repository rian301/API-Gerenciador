using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class ExpenseControlDocService : ServiceBaseCRUD<ExpenseControlDoc, Guid>, IExpenseControlDocService
	{
		private readonly IExpenseControlDocRepository _mentoredRepository;

		public ExpenseControlDocService(IExpenseControlDocRepository repository, INotificationHandler<DomainNotification> notification)
			: base(repository, notification)
		{
			_mentoredRepository = repository;
		}

		public Task<List<ExpenseControlDoc>> GetAllByExpenseControlIdAsync(int expenseId) => _mentoredRepository.GetAllByExpenseControlIdAsync(expenseId);
		public Task<List<ExpenseControlDoc>> GetAllActives(int expenseId) => _mentoredRepository.GetAllActives(expenseId);
		public Task<ExpenseControlDoc> GetDocsActivesbyType(int expenseId, TypeDocEnum typedoc) => _mentoredRepository.GetDocsActivesbyType(expenseId, typedoc);
		public Task<ExpenseControlDoc> ChangeStatusDoc(Guid docId, int expenseId, TypeDocEnum typedoc) => _mentoredRepository.ChangeStatusDoc(docId, expenseId, typedoc);

	}
}
