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
    public class PatrimonyDocService : ServiceBaseCRUD<PatrimonyDoc, Guid>, IPatrimonyDocService
	{
		private readonly IPatrimonyDocRepository _mentoredRepository;

		public PatrimonyDocService(IPatrimonyDocRepository repository, INotificationHandler<DomainNotification> notification)
			: base(repository, notification)
		{
			_mentoredRepository = repository;
		}

		public Task<List<PatrimonyDoc>> GetAllByPatrimonyIdAsync(int mentoredId) => _mentoredRepository.GetAllByPatrimonyIdAsync(mentoredId);
		public Task<List<PatrimonyDoc>> GetAllActives(int customerDependentId) => _mentoredRepository.GetAllActives(customerDependentId);
		public Task<PatrimonyDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc) => _mentoredRepository.GetDocsActivesbyType(customerDependentId, typedoc);
		public Task<PatrimonyDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc) => _mentoredRepository.ChangeStatusDoc(docId, mentoredId, typedoc);

	}
}
